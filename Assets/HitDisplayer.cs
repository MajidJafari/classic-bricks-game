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
            Display(streak);
            if (!displayer.enabled) {
                displayer.enabled = true;
            }
        }
        
    }

    public void OnLoseLife() {
        displayer.enabled = false;
    }

    private void Display(int streak) {
        displayer.SetText(streak.ToString());
    }
}
