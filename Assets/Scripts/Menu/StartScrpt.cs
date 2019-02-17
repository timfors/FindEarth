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
    }
    void Awake()
    {
        startTime = Time.time;
    }
    public void OnClick()
    {
        if (Time.time - startTime > 1 && !GlobalConfig.GetGlobalConfig.isPlaying)
        {
            GlobalConfig.GetGlobalConfig.isPlaying = true;
            StartCoroutine(CheckForDeath());
        }
    }
    IEnumerator CheckForDeath()
    {
        if (GlobalConfig.GetGlobalConfig.isPlaying == false)
        {
            startTime = Time.time;
        }
        yield return null;
    }
}
