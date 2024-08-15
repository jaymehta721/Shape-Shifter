using System.Collections;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
        StartCoroutine(CalculateDistanceToPlayer());
    }

    private IEnumerator CalculateDistanceToPlayer()
    {
        while(true)
        {
            if(_player.transform.position.y - transform.position.y > 50)
            {
                Destroy(this.gameObject);
            }
    
            yield return new WaitForSeconds(1.0f);
        }
    }
}
