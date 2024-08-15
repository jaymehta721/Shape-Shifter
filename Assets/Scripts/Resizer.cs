using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public Vector3 maxScale;
    public float speed = 2f;
    public float duration = 5f;
    public bool repeat;

    private Vector3 _minScale;

    private IEnumerator Start()
    {
        _minScale = transform.localScale;
        while(repeat)
        {
            yield return RepeatResize(_minScale, maxScale, duration);
            yield return RepeatResize(maxScale, _minScale, duration);
        }
    }

    private IEnumerator RepeatResize(Vector3 a, Vector3 b, float time)
    {
        var i = 0.0f;
        var rate = (1.0f / time) * speed;
        
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
