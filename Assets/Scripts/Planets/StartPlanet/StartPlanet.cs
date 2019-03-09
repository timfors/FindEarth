using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlanet : MonoBehaviour
{
    [SerializeField]
    private PlanetData planetData;

    void Start()
    {
        ShowPlanet();
    }

    public void ShowPlanet()
    {
        StartCoroutine(Up());
    }

    public void RemovePlanet()
    {
        if (GlobalConfig.GetGlobalConfig.isReady)
        {
            StopAllCoroutines();
            StartCoroutine(Down());
        }
    }

    
    IEnumerator Up()
    {
        while (true)
        {
            if (transform.position.y > 1.5)
            {
                break;

            }
            transform.Translate(new Vector2(0, 1) * planetData.Speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Down()
    {
        while (true)
        {
            if (transform.position.y < -4)
            {
                Destroy(gameObject, 1);
                break;

            }
            transform.Translate(new Vector2(0, -1) * planetData.Speed * Time.deltaTime);
            yield return null;
        }
    }
}
