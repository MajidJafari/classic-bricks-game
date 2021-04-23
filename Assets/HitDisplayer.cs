using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDisplayer : MonoBehaviour, IHitListener, ILoseLifeListener
{    
    public TMPro.TMP_Text displayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        Ball.onHit += OnHit;
        BallRelaunch.onMiss += OnLoseLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(HitTypes type, int streak) {
        if (type == HitTypes.Brick) {
            Display(streak.ToString());
        }
        
    }

    public void OnLoseLife() =>
        Display("");

    private void Display(string text) =>
        displayer.SetText(text);
}
