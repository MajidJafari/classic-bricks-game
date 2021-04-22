﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public delegate void OnLifeZero();
    public static event OnLifeZero onLifeZero;
    public int lives;
    private int initialLives;
    private int score { set; get; } = 0;
    public int scoringAmount; 
    public TMPro.TMP_Text scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        initialLives = lives;
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
        if (lives <= 0) {
            LifeIsZero();
        }
    }

    public void Score() 
    {
        this.score += scoringAmount;
        UpdateScoreboard();
    }

    private void UpdateScoreboard() =>
        this.scoreboard.SetText("Score: " + score + "\n" + "Lives: " + lives);

    void LifeIsZero() {
        if (onLifeZero != null) {
            onLifeZero();
        }
        lives = initialLives;
    }    
}
