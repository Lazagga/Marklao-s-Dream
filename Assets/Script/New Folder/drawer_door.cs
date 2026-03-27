using System.Collections;
using UnityEngine;

public class drawer_door : BaseDoor
{
    private static readonly Vector3 OpenOffset = new(0f, 0f, 0.4f);

    protected override IEnumerator OpenCoroutine()
    {
        doorState = DoorState.Animating;
        yield return AnimateTranslation(OpenOffset);
        doorState = DoorState.Open;
    }

    protected override IEnumerator CloseCoroutine()
    {
        doorState = DoorState.Animating;
        yield return AnimateTranslation(-OpenOffset);
        doorState = DoorState.Closed;
    }

    private IEnumerator AnimateTranslation(Vector3 delta)
    {
        Vector3 start = transform.position;
        Vector3 end = start + delta;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / AnimDuration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        transform.position = end;
    }
}
