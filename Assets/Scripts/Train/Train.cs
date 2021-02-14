using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Train : MonoBehaviour
{
    private const float MoveUnitPerSeconds = 3f;

    void Update()
    {
        this.Wait(.5f, Move);
    }

    void Move()
    {
        Vector3 position = transform.position;
        position.x -= MoveUnitPerSeconds * Time.deltaTime;
        transform.position = position;
    }
}
