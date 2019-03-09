using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameEvent beforePlay;

    [SerializeField]
    private GameEvent afterPlay;

    public void Click()
    {
        if (GlobalConfig.GetGlobalConfig.isPlaying)
        {
            afterPlay.Raise();
        }
        else
        {
            beforePlay.Raise();
        }
    }
}
