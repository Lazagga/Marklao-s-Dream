using System.Collections;
using UnityEngine;

public class file_storage_door : BaseDoor
{
    public enum Side { Left, Right }
    public Side where;

    protected override IEnumerator OpenCoroutine()
    {
        doorState = DoorState.Animating;
        Quaternion delta = where == Side.Left
            ? Quaternion.Euler(0f, 90f, 0f)
            : Quaternion.Euler(0f, -90f, 0f);
        yield return AnimateRotation(delta);
        doorState = DoorState.Open;
    }

    protected override IEnumerator CloseCoroutine()
    {
        doorState = DoorState.Animating;
        Quaternion delta = where == Side.Left
            ? Quaternion.Euler(0f, -90f, 0f)
            : Quaternion.Euler(0f, 90f, 0f);
        yield return AnimateRotation(delta);
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
