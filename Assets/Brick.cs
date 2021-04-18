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

    void OnCollisionEnter(Collision collisionInfo)
    {
        Death();
    }

    void Death() {
        if (onDeath != null) {
            onDeath();
        }
        Destroy(this.gameObject);
    }
}
