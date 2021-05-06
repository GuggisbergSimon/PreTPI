using System.Collections;
using UnityEngine;

public class LerpCoroutineModel : MonoBehaviour
{
    private Coroutine _coroutine;

    public void Lerp(Transform t, Vector3 a, Vector3 b, float time)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        time = time <= 0f ? StaticsValues.SMALLEST_INT : time;
        _coroutine = StartCoroutine(VectorLerp(t, a, b, 1 / time));
    }

    private IEnumerator VectorLerp(Transform tr, Vector3 a, Vector3 b, float speed)
    {
        for (float t = 0; t < 1f; t += Time.deltaTime * speed)
        {
            tr.position = Vector3.Lerp(a, b, t);
            yield return null;
        }
    }
}