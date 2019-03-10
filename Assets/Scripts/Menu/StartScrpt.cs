using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScrpt : MonoBehaviour
{
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        StartCoroutine(ReadyCheck());
    }
    void Awake()
    {
        startTime = Time.time;
    }
    IEnumerator ReadyCheck()
    {
        while (true)
        {
            if (Time.time - startTime > 1.4f)
            {
                GlobalConfig.GetGlobalConfig.isReady = true;
                break;
            }
            yield return null;
        }
    }
    public void OnClick()
    {
        if (GlobalConfig.GetGlobalConfig.isReady)
        {
            GlobalConfig.GetGlobalConfig.isPlaying = true;
            StartCoroutine(CheckForDeath());
        }
    }
    IEnumerator CheckForDeath()
    {
        while (true)
        {
            if (GlobalConfig.GetGlobalConfig.isPlaying == false)
            {
                startTime = Time.time;
                StartCoroutine(ReadyCheck());
                break;
                
            }
            yield return null;
        }
    }
}
