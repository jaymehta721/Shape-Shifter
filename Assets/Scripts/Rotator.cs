using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotation = 45f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);   
    }
}
