using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    static PlanetGenerator planetGenerator;
    public static PlanetGenerator GetPlanetGenerator
    {
        get
        {
            return planetGenerator;
        }
    }

    [SerializeField]
    GameObject parent;

    [SerializeField]
    List<Planet> planets;

    float[] x = { -1.5f, -1.25f, -1f, -0.75f, -0.5f, -0.25f, 0f, 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f };
    long planetCount;
    int firstNewPlanet;
    GameObject obj;

    private void Awake()
    {
        planetGenerator = this;
        planetCount = 0;
        firstNewPlanet = 0;
    }

    private void Start()
    {
        List<Planet> pl = planets.FindAll(p => p.GetType() != typeof(CommonPlanet)).OrderBy(p => p.start).ToList();
        //firstNewPlanet = pl[0].start;
        StartCoroutine(WaitingStart());
    }

    public IEnumerator WaitingStart()
    {
        while (true)
        {
            if (!GlobalConfig.GetGlobalConfig.start)
            {
                yield return null;
            }
            else
            {
                StartCoroutine(Generate());
                yield break;
            }
        }
    }

    IEnumerator Generate()
    {
        while (true)
        {
            if (planetCount < firstNewPlanet)
            {
                obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
                obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);

            }
            else
            {
                foreach (Planet planet in planets)
                {
                    if (planetCount >= planet.start && planet.CheckProbability())
                    {
                        obj = Instantiate(planet.obj, parent.transform, false);
                        obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
                    }
                }

                if (obj == null)
                {
                    obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
                    obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
                }
            }

            while (obj.transform.localPosition.y > 0.5f)
            {
                yield return null;
            }

            yield return null;
        }
    }
}
