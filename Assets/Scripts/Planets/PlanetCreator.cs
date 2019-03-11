using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allPlanetTypes;

    void Create()
    {
        GameObject planet = allPlanetTypes[Random.Range(0, allPlanetTypes.Length - 1)];
        //create planet and set parent as field
        Instantiate(planet, transform.position + new Vector3( Random.Range(-0.5f, 0),Random.Range(-5, 1), 0), Quaternion.identity).transform.parent = transform.parent;
    }

    IEnumerator Creator()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Create();
        }
    }

    public void StartCreate()
    {
        if (GlobalConfig.GetGlobalConfig.isReady)
        {
            StartCoroutine(Creator());
        }
    }

    public void StopCreate()
    {
        if (!GlobalConfig.GetGlobalConfig.isPlaying)
        {
            StopAllCoroutines();
        }
    }
}
