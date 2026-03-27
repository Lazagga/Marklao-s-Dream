using System.Collections;
using UnityEngine;

public class cabinet_door : BaseDoor
{
    protected override void Init()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    protected override IEnumerator OpenCoroutine()
    {
        doorState = DoorState.Animating;
        yield return AnimateRotation(Quaternion.Euler(0f, 0f, -90f));
        doorState = DoorState.Open;
    }

    protected override IEnumerator CloseCoroutine()
    {
        doorState = DoorState.Animating;
        yield return AnimateRotation(Quaternion.Euler(0f, 0f, 90f));
        doorState = DoorState.Closed;
    }

    private IEnumerator AnimateRotation(Quaternion deltaRot)
    {
        Quaternion start = transform.localRotation;
        Quaternion end = start * deltaRot;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / AnimDuration;
            transform.localRotation = Quaternion.Lerp(start, end, t);
            yield return null;
        }
        transform.localRotation = end;
    }
}
