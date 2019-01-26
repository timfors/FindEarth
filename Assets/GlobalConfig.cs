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
    private void Awake()
    {
        globalConfig = this;
        start = false;
    }
}
