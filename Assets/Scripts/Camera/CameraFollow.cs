using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject jimmy;

    private Vector3 offset;

    void Awake()
    {
        jimmy = GameObject.FindGameObjectWithTag("Jason");
    }
    
    void Start()
    {
        offset = transform.position - jimmy.transform.position;
    }

    void LateUpdate()
    {
        transform.position = jimmy.transform.position + offset;
    }
}
