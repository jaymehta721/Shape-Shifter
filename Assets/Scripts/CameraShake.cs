using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private const float Duration = 0.15f;
    private const float Magnitude = 0.05f;

    public IEnumerator Shake()
    {
        var originalPosition = transform.localPosition;
        var elapsed = 0.0f;

        while(elapsed < Duration)
        {
            var x = Random.Range(-1f, 1f) * Magnitude;
            var y = Random.Range(-1f, 1f) * Magnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
