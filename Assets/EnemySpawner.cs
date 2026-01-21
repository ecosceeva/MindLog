using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 1;
    public GameObject spawnGameObject;
    public Transform[] spawnPoints; 
    private float timer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (timer > spawnTime)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(spawnGameObject, randomPoint.position, randomPoint.rotation);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
