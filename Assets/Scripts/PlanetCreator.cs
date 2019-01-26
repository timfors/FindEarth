using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreator : MonoBehaviour
{
    public float min, max;
    public GameObject[] allPlanets;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SleepAndGo());
    }

    void CreatePlanet() {
        GameObject planet = Instantiate(allPlanets[Random.Range(0, allPlanets.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SleepAndGo());
        Destroy(planet, 20);
    }


    // Update is called once per frame
    IEnumerator SleepAndGo()
    {
        yield return new WaitForSeconds(Random.Range(Random.Range(min, max - 2), max));
        CreatePlanet();
    }
}
