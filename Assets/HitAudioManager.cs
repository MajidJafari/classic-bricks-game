using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudioManager : MonoBehaviour, IHitListener, ILoseLifeListener, ILifeZeroListener
{
    private static HitAudioManager _instance;
    public AudioClip brickHit;
    public AudioClip playerHit;
    public AudioClip wallHit;
    public float initialPitch = 1;
    private float currentPitch;
    public int hitStreakStep = 8;
    public float additionalHitPitch = 0.05f;
    private AudioSource audioSource;
    // Start is called before the first frame update
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

    void Start() {
        ResetPitch();
    }

    void OnEnable()
    {
        Ball.onHit += OnHit;
        BallRelaunch.onMiss += OnLoseLife;
        Scoring.onLifeZero += OnLifeZero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(HitTypes type, int streak) {
        if (type != HitTypes.Other) {
            if (streak % hitStreakStep == 0) {
                this.currentPitch += additionalHitPitch;
            }
            switch(type) {
                case HitTypes.Brick:
                    Play(brickHit);
                    break;
                case HitTypes.Player:
                    Play(playerHit);
                    break;
                case HitTypes.Wall:
                    Play(wallHit);
                    break;
            }
        }
    }

    private void Play(AudioClip audio) {
        this.audioSource.clip = audio;
        this.audioSource.pitch = currentPitch;
        audioSource.Play();
    }

    private void InitializeAudioSource() {
        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.loop = false;
        this.audioSource.playOnAwake = false;
    }

    public void OnLoseLife() {
        ResetPitch();
    }

    private void ResetPitch() {
        this.currentPitch = initialPitch;
        this.audioSource.pitch = initialPitch;
    }

    public void OnLifeZero() {
        InitializeAudioSource();
    }
}
