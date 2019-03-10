using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig : MonoBehaviour
{
    static GlobalConfig globalConfig;
    public static GlobalConfig GetGlobalConfig
    {
        get { return globalConfig; }
    }

    public bool isReady;
    public bool isPlaying;
    public float speed;
    public int points;
    public int record;

    private void Awake()
    {
        isReady = false;
        globalConfig = this;
        isPlaying = false;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            record = PlayerPrefs.GetInt("Points");
        }
    }

    public void SetPoints(int points)
    {
        this.points += points;
    }

    public void SetRecord()
    {
        if (points > record)
        {
            record = points;
            PlayerPrefs.SetInt("Points", record);
        }
    }
}
