using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTimer : MonoBehaviour
{
    private float totalSeconds = 0;
    private float elapsedSeconds = 0;
    private bool running = false;
    private bool started = false;

    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }
    public bool Finished => started && !running;
    
    public bool Running => running;

    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }
    
    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }
}
