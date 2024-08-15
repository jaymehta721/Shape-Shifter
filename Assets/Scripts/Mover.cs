using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool upDown;
    public float delta;
    public float speed;
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        switch (upDown)
        {
            case false:
            {
                var newPos = _startPos;
                newPos.x += delta * Mathf.Sin(Time.time * speed);
                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
                break;
            }
            case true:
            {
                var newPos = _startPos;
                newPos.y += delta * Mathf.Sin(Time.time * speed);
                transform.position = new Vector3(transform.position.x, newPos.y, transform.position.z);
                break;
            }
        }
    }
}
