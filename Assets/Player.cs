using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public string moveLeftKeyboard;
    public string moveRightKeyboard;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var translationAmount = this.speed * Time.deltaTime;
        if(Input.GetKey(this.moveLeftKeyboard)) {
            transform.Translate(-translationAmount, 0, 0);
        }
        else if (Input.GetKey(this.moveRightKeyboard)) {
            transform.Translate(translationAmount, 0, 0);
        }

        var horizontalOffset = this.speed * Time.deltaTime * Input.GetAxis("Mouse X");
        transform.Translate(horizontalOffset, 0, 0);
    }

    void OnTriggerEnter(Collider other) 
    {
        var ball = other.GetComponent<Ball>();
        ball.control(other.transform.position.x > gameObject.transform.position.x);
    }
}
