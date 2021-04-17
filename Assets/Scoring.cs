﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int lives;
    private int score { set; get; } = 0;
    public int scoringAmount;
    public TMPro.TMP_Text scoreboard;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        Brick.onDeath += Score;
        BallRelaunch.onMiss += LoseLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseLife()
    {
        this.lives--;
        UpdateScoreboard();
    }

    public void Score() 
    {
        this.score += scoringAmount;
        UpdateScoreboard();
    }

    private void UpdateScoreboard() =>
        this.scoreboard.SetText("Score: " + score + "\n" + "Lives: " + lives);
}
