using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public NavMeshAgent Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(SpawnManager.Instance.PlayerPos.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("walls"))
        {
            SpawnManager.Instance.playAudio();
            SpawnManager.Instance.Add();
            Destroy(gameObject);
           
        }
    }
}
