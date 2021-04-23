using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAudioManager : AudioManager, ILoseLifeListener, ILifeZeroListener
{
    private static StaticAudioManager _instance;
    public AudioClip missAudio;
    public AudioClip gameoverAudio;
    public AudioClip startAudio;
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
        Scoring.onLifeZero += OnLifeZero;
        TitleMenu.onGameplayStart += OnGameplayStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoseLife() {
        Play(missAudio);
    }

    public void OnLifeZero() {
        Play(gameoverAudio);
    }

    public void OnGameplayStart() {
        Play(startAudio);
    }
}
