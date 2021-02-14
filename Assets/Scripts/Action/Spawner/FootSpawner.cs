using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSpawner : MonoBehaviour
{
    private GameObject prefabFoot;

    private const float SpawnDelaySeconds = 1f;

    private float spawnY;
    private float minSpawnX;
    private float maxSpawnX;
    private float minSpawnZ;
    private float maxSpawnZ;

    private GameObject jason;
    private SpawnerTimer timer;

    private Vector3 currentPosition;
    
    void Awake()
    {
        jason = GameObject.FindGameObjectWithTag("Jason");
        prefabFoot = (GameObject)Resources.Load("Prefabs/Environment/Foot");
    }

    void Start()
    {
        timer = gameObject.AddComponent<SpawnerTimer>();
        timer.Duration = SpawnDelaySeconds;
        timer.Run();
    }
    
    
    void Update()
    {
        currentPosition = jason.transform.position;

        if (timer.Finished)
        {
            GameObject foot = Instantiate(prefabFoot);
            foot.transform.position = GetSpawnPosition();
            timer.Run();
        }
    }
    
    Vector3 GetSpawnPosition()
    {
        minSpawnX = currentPosition.x + -2f;
        maxSpawnX = currentPosition.x + 2f;

        minSpawnZ = currentPosition.z + -1f;
        maxSpawnZ = currentPosition.z + 5f;

        float randomSpawnX = Random.Range(minSpawnX, maxSpawnX);
        float randomSpawnZ = Random.Range(minSpawnZ, maxSpawnZ);
        
        return new Vector3(randomSpawnX, 5f, randomSpawnZ);
    }
}
