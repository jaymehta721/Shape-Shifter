using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float yOffset = 10f;
    private const float SmoothTime = 0.15f;
    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        var targetPos = player.transform.TransformPoint(new Vector3(0, yOffset, -10));
        targetPos = new Vector3(0, targetPos.y, targetPos.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, SmoothTime);
    }
}
