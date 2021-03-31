using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public float launchTimer;
    public Vector2 speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    private float GetTranslationAmount(float speed) => speed * Time.deltaTime;
    // Update is called once per frame
    void Update()
    {
        this.launchTimer -= Time.deltaTime;
        if(this.launchTimer <= 0) {
            transform.Translate(
                new Vector3(
                    this.GetTranslationAmount(this.speed.x),
                    this.GetTranslationAmount(this.speed.y),
                    0
                )
            );
        }
        this.launchTimer = 0.0f;
    }

    void OnTriggerEnter(Collider other) 
    {
        GetComponent<AudioSource>().Play();
    }

    public void handleSpeed(WallTypes wallType)
    {
        switch (wallType)
        {
            case WallTypes.Side:
                this.speed.x = -this.speed.x;
                break;
            case WallTypes.Upper:
                this.speed.y = -this.speed.y;
                break;
        }
    }
}
