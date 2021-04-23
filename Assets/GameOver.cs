using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour, ILifeZeroListener
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Scoring.onLifeZero += OnLifeZero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLifeZero() {
        SceneManager.LoadScene("TitleMenuScene");
    }
}
