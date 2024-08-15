using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstaclesArray;

    private int _playerDistanceIndex = -1;

    private int _obstacleCount;
    private int _obstacleIndex = 0;
    private const int DistanceToNext = 30;

    private void Start()
    {
        _obstacleCount = obstaclesArray.Length;
        SpawnObstacle();
    }

    private void Update()
    {
        var playerDistance = (int)(player.transform.position.y / (DistanceToNext));

        if (_playerDistanceIndex == playerDistance)
        {
            return;
        }

        SpawnObstacle();

        _playerDistanceIndex = playerDistance;
    }

    private void SpawnObstacle()
    {
        var randomInt = Random.Range(0, _obstacleCount);
        var newObstacle = Instantiate(obstaclesArray[randomInt], new Vector3(0, _obstacleIndex * DistanceToNext),
            Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        _obstacleIndex++;
    }
}