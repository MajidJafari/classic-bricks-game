using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public delegate void OnDeath();
    public static event OnDeath onDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        var randomMoveForward = new System.Random().Next(0, 2) == 0 ? true : false;
        ball.control(randomMoveForward);
        Death();
    }

    void Death() {
        if (onDeath != null) {
            onDeath();
        }
        Destroy(this.gameObject);
    }
}
