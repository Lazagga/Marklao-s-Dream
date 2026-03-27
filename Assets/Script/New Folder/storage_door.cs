using System.Collections;
using UnityEngine;

public class storage_door : BaseDoor
{
    private static readonly Vector3 OpenOffset = new(-0.45f, 0f, 0f);

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
        Vector3 start = transform.localPosition;
        Vector3 end = start + delta;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / AnimDuration;
            transform.localPosition = Vector3.Lerp(start, end, t);
            yield return null;
        }
        transform.localPosition = end;
    }
}
