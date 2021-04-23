using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public delegate void OnGameplayStart();
    public static event OnGameplayStart onGameplayStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) {
            SceneManager.LoadScene("GameplayScene");
            if (onGameplayStart != null) {
                onGameplayStart();
            }
        }
    }
}
