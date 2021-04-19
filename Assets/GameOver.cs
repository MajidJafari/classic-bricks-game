using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        Scoring.onLifeZero += GameIsOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameIsOver() {
        SceneManager.LoadScene("TitleMenuScene");
    }
}
