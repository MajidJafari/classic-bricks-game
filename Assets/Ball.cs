using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public delegate void OnBrickHit(int hitStreak);
    public static event OnBrickHit onBrickHit;
    public float launchTimer;
    public Vector2 initialSpeed;
    public int BrickHitStreakStep = 8;
    public Vector2 brickHitAdditionalSpeed;
    private Vector2 currentSpeed;
    private int brickHitsStreak = 0;
    // Start is called before the first frame update
    void Start()
    {
        resetSpeed();
    }

    private float GetTranslationAmount(float speed) => speed * Time.deltaTime;
    // Update is called once per frame
    void Update()
    {
        this.launchTimer -= Time.deltaTime;
        if(this.launchTimer <= 0) {
            transform.Translate(
                new Vector3(
                    this.GetTranslationAmount(this.currentSpeed.x),
                    this.GetTranslationAmount(this.currentSpeed.y),
                    0
                )
            );
        }
        this.launchTimer = 0.0f;
    }

    void OnTriggerEnter(Collider other) 
    {
        var relaunch = other.GetComponent<BallRelaunch>();
        if (relaunch) {
            this.relaunch(relaunch.relaunchPosition);    
            GetComponent<AudioSource>().Play();
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        var wall = collisionInfo.gameObject.GetComponent<Wall>();
        var brick = collisionInfo.gameObject.GetComponent<Brick>();
        var player = collisionInfo.gameObject.GetComponent<Player>();

        if (wall) {
            handleSpeed(wall.wallType);
        }
        else if (player) {
            control(this.transform.position.x > collisionInfo.transform.position.x);
        }
        else if (brick) {
            handleBrickHit();
            var randomMoveForward = new System.Random().Next(0, 2) == 0 ? true : false;
            control(randomMoveForward);
        }
        GetComponent<AudioSource>().Play();
    }

    public void handleSpeed(WallTypes wallType)
    {
        switch (wallType)
        {
            case WallTypes.Side:
                this.currentSpeed.x = -this.currentSpeed.x;
                break;
            case WallTypes.Upper:
                this.currentSpeed.y = -this.currentSpeed.y;
                break;
        }
    }

    public void control(bool moveForward) {
        this.currentSpeed.y = -this.currentSpeed.y;
        var coefficient = moveForward ? 1 : -1;
        this.currentSpeed.x = coefficient * Mathf.Abs(this.currentSpeed.x);
    }

    public void relaunch(Vector3 relaunchPosition)
    {
        this.brickHitsStreak = 0;
        resetSpeed(true);
        this.transform.position = relaunchPosition;
        this.launchTimer = this.launchTimer / 2f;
    }

    private void resetSpeed(bool moveDownward = false)
    {
        this.currentSpeed = this.initialSpeed;
        if (moveDownward) {
            this.currentSpeed.y = -this.initialSpeed.y;
        }
    }

    private void handleBrickHit() {
        this.brickHitsStreak++;
        if (brickHitsStreak % BrickHitStreakStep == 0) {
            currentSpeed.x += System.Math.Sign(currentSpeed.x) * brickHitAdditionalSpeed.x;
            currentSpeed.y += System.Math.Sign(currentSpeed.y) * brickHitAdditionalSpeed.y;
        }

        if(onBrickHit != null) {
            onBrickHit(brickHitsStreak);
        }
    }

}
