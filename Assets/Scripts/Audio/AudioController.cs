using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]private AudioSource EffectsSource;

    [HideInInspector] public AudioClip jasonVoice;
    [HideInInspector] public AudioClip jason;
    [HideInInspector] public AudioClip catchup;
    [HideInInspector] public AudioClip theme;
    [HideInInspector] public AudioClip lightSound;

    public static AudioController Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        jasonVoice = (AudioClip)Resources.Load("Sounds/kid voice");
        jason = (AudioClip)Resources.Load("Sounds/jason");
        catchup = (AudioClip)Resources.Load("Sounds/catchup");
        theme = (AudioClip)Resources.Load("Sounds/theme");
        lightSound = (AudioClip)Resources.Load("Sounds/light");
    }

    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }
}
