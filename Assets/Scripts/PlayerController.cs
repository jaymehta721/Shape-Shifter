using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectibleEffect;

    public Rigidbody rb;
    public float delta = 2.3f;
    public float lrSpeed = 2.5f;
    public float upSpeed = 2.5f;

    public AudioClip itemSound;
    public AudioClip deathSound;

    private Vector3 _startPos;
    private bool _isDead;

    private GameController _gameController;
    private float _hueValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _startPos = transform.position;

        _gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    private void Start()
    {
        _hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();
    }

    private void FixedUpdate()
    {
        if (_isDead)
        {
            return;
        }
        
        var newPos = _startPos;
        newPos.x += delta * Mathf.Sin(Time.time * lrSpeed);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);

        if(Input.GetMouseButton(0))
        { 
            rb.AddForce(transform.up * upSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                SoundManager.instance.PlaySingle(deathSound);
                Death();
                break;
            case "Collectible":
                SoundManager.instance.PlaySingle(itemSound);
                GetItem(other);
                break;
        }
    }

    private void GetItem(Collider other)
    {
        SetBackgroundColor();

        Destroy(Instantiate(collectibleEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject);
        _gameController.AddScore();
    }

    private void Death()
    {
        _isDead = true;

        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 0.7f);
        StopPlayer();

        _gameController.CallGameOver();
    }

    private void StopPlayer()
    {
        Destroy(this.GetComponent<SphereCollider>());

        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
    }

    private void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(_hueValue, 0.6f, 0.8f);
        _hueValue += 0.1f;
        if(_hueValue >= 1)
        {
            _hueValue = 0;
        }
    }
}
