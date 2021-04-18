using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRelaunch : MonoBehaviour
{
    public delegate void OnMiss();
    public static event OnMiss onMiss;
    public Vector3 relaunchPosition;
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
        Miss();
    }

    void Miss() {
        if (onMiss != null) {
            onMiss();
        }
    }
}
