using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameEvent onTapped;

    [SerializeField]
    Button button;


    public ParticleSystem dust;

    private void Awake()
    {
        //set Player in Camera Follow script
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().player = transform;
        //Set Player in Button script
        button = GameObject.FindGameObjectWithTag("GameController").GetComponent<Button>();
        button.onClick.RemoveListener(ButtonClick);
        button.onClick.AddListener(ButtonClick);
    }
    void OnDestroy()
    {
        GlobalConfig.GetGlobalConfig.isPlaying = false;
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
        if(transform.parent)
        {
            TurnOnMovementComponent();
            transform.parent = null;
            onTapped.Raise();
        }
    }
}
