using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlanetCreateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlanet;

    public void CreatePlanet()
    {
        if (!GlobalConfig.GetGlobalConfig.isPlaying)
        {
            Instantiate(startPlanet, transform.position, Quaternion.identity);
        }
    }
}
