using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameEvent onTapped;


    public ParticleSystem dust;

    private void Awake()
    {
        //set Player in Camera Follow script
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().player = transform;
    }
    void OnDestroy()
    {
        GlobalConfig.GetGlobalConfig.isPlaying = false;
        GlobalConfig.GetGlobalConfig.isReady = false;
        onTapped.Raise();
    }

    void TurnOffMovementComponent()
    {
        gameObject.GetComponent<PlayerMov>().enabled = false;
    }

    void TurnOnMovementComponent()
    {
        gameObject.GetComponent<PlayerMov>().enabled = true;
    }

    public void OnColided()
    {
        TurnOffMovementComponent();
        dust.Play();
    }

    public void ButtonClick()
    {
        if(transform.parent && GlobalConfig.GetGlobalConfig.isPlaying)
        {
            TurnOnMovementComponent();
            transform.parent = null;
            onTapped.Raise();
        }
    }
}
