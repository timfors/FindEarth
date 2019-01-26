using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOverManager;

    private void Awake()
    {
        gameOverManager = this;
    }
}
