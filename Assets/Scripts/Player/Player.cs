using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameEvent onTapped;

    public ParticleSystem dust;
    private void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
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
        if(GlobalConfig.GetGlobalConfig.isPlaying && transform.parent)
        {
            TurnOnMovementComponent();
            onTapped.Raise();
            transform.parent = null;
        }
    }
}
