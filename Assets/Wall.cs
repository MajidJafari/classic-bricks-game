using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallTypes {
    Side, Upper
}
public class Wall : MonoBehaviour
{
    public WallTypes wallType;
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
        ball.handleSpeed(this.wallType);
    }
}
