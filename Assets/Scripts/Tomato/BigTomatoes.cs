using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BigTomatoes : MonoBehaviour
{
    private const float MoveUnitPerSeconds = 5f;

    private AudioClip[] clips = new AudioClip[2];

    void Start()
    {
        InvokeRepeating("Voice", 2f, 5f);
    }
    
    void Update()
    {
        Vector3 position = transform.position;
        position.z += MoveUnitPerSeconds * Time.deltaTime;
        transform.position = position;
    }

    void Voice()
    {
        AudioController.Instance.Play(AudioController.Instance.catchup);
        
        this.Wait(1.5f, () =>
        {
            AudioController.Instance.Play(AudioController.Instance.jason);
        });
    }
}
