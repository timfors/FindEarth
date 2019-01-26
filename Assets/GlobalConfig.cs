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

    public bool start;
    public float speed;
    public bool left;
    public bool right;
    public int points;
    public int record;

    private void Awake()
    {
        globalConfig = this;
        start = false;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Pints"))
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
