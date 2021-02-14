using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LittleTomato : MonoBehaviour
{
    private float moveUnitPerSeconds = 6f;
    private Rigidbody rb;
    
    private GameObject trainPrefab;
    [SerializeField] private Transform trainPosition;
    
    bool isTrainSpawned = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trainPrefab = (GameObject)Resources.Load("Prefabs/Environment/Train");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        rb.AddForce(direction * moveUnitPerSeconds * Time.deltaTime, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bar") && !isTrainSpawned)
        {
            GameObject train = Instantiate(trainPrefab);
            train.transform.position = trainPosition.position;

            isTrainSpawned = true;
        }
        
        if (other.gameObject.CompareTag("Foot"))
        {
            
            LevelChanger.Instance.LoadLevel();
        }

        if (other.gameObject.CompareTag("Portal"))
        {   
            LevelChanger.Instance.LoadNextLevel();
        }
    }
}
