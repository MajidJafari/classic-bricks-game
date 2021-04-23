using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissAudioManager : AudioManager, ILoseLifeListener
{
    private static MissAudioManager _instance;
    public AudioClip missAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeAudioSource();
    }

    void OnEnable() {
        BallRelaunch.onMiss += OnLoseLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoseLife() {
        Play(missAudio);
    }
}
