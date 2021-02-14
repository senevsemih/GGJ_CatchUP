using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LastScene : MonoBehaviour
{
    [SerializeField] private GameObject spotlight1;
    [SerializeField] private GameObject spotlight2;


    void Start()
    {
        Invoke("SceneActive", 3f);
    }

    void SceneActive()
    {
        AudioController.Instance.Play(AudioController.Instance.lightSound);
        spotlight1.SetActive(true);
        spotlight2.SetActive(true);
        
        this.Wait(10f, () =>
        {
            LevelChanger.Instance.LoadNextLevel();
        });
    }
}
