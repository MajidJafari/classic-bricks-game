using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksManager : MonoBehaviour
{
    public Vector2 matrixSize;
    public Vector3 brickScale;
    public GameObject brickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int j = 0; j < matrixSize.y; j++) {
            for(int i = 0; i < matrixSize.x; i++) {
                var brick = Instantiate(brickPrefab, new Vector3(i * 2 - 14, j - 1, 0), Quaternion.identity);
                brick.GetComponentInChildren<Renderer>().material.color = GetColor(j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Color GetColor(int y) {
        if (y < 2) {
            return Color.yellow;
        }
        else if (y < 4) {
            return Color.cyan;
        }
        else if (y < 6) {
            return Color.blue;
        }
        else {
            return Color.red;
        }

    }
}
