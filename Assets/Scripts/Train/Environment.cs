using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private Transform bar;

    private float speed = 20f;

    void Update()
    {
        if (bar.localRotation.z > 0.7)
        {
            speed = 0;
            StartCoroutine(TheyLost());
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Papa"))
        {
            InvokeRepeating("MoveBarDown", 0f, .01f);
        }
    }

    void MoveBarDown()
    {
        bar.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator TheyLost()
    {
        yield return new WaitForSeconds(8f);
        
        LevelChanger.Instance.LoadNextLevel();
    }
}
