using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudioManager : MonoBehaviour, IHitListener
{
    public AudioClip brickHit;
    public AudioClip playerHit;
    public AudioClip wallHit;
    public float pitch = 1;
    public int hitStreakStep = 8;
    public float additionalHitPitch = 0.05f;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        InitializeAudioSource();
    }

    void OnEnable()
    {
        Ball.onHit += OnHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(HitTypes type, int streak) {
        if (streak % hitStreakStep == 0) {
            this.pitch += additionalHitPitch;
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

    private void Play(AudioClip audio) {
        this.audioSource.clip = audio;
        this.audioSource.pitch = pitch;
        audioSource.Play();
    }

    private void InitializeAudioSource() {
        this.audioSource.pitch = pitch;
        this.audioSource.loop = false;
        this.audioSource.playOnAwake = false;
    }
}
