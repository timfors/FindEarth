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

    public Vector3 parentStartPos;

    float[] x = { -1.5f, -1.25f, -1f, -0.75f, -0.5f, -0.25f, 0f, 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f };
    long planetCount;
    GameObject obj;

    private void Awake()
    {
        planetGenerator = this;
        planetCount = 0;
    }

    private void Start()
    {
        parentStartPos = parent.transform.position;
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

    public void Clear()
    {
        planetCount = 0;

        foreach (Transform obj in parent.transform)
        {
            if (obj.GetComponent<PlanetGenerator>() == null && !obj.Equals(parent))
            {
                Destroy(obj.gameObject);
            }
        }

        StartCoroutine(WaitingStart());
    }

    IEnumerator Generate()
    {
        while (true)
        {
            if (planetCount == 0)
            {
                obj = Instantiate(planets.Find(p => p is Earth).obj, parent.transform, false);
                obj.transform.localPosition = new Vector3(x[Random.Range(4, 9)], 3f, 0f);
                planetCount++;
            }
            else if (planetCount <= 10)
            {
                FirstStep();
            }
            else if (planetCount <= 20)
            {
                SecondStep();
            }
            else if (planetCount <= 30)
            {
                ThirdStep();
            }
            else
            {
                foreach (Planet planet in planets)
                {
                    if (planetCount >= planet.start && planet.CheckProbability())
                    {
                        obj = Instantiate(planet.obj, parent.transform, false);
                        obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
                        planetCount++;
                    }
                }

                if (obj == null)
                {
                    obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
                    obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
                    planetCount++;
                }
            }

            while (obj.transform.localPosition.y > 0.5f)
            {
                yield return null;
            }

            yield return null;
        }
    }

    void FirstStep()
    {
        if (planetCount == 10)
        {
            obj = Instantiate(planets.Find(p => p is Earth).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }
        else
        {
            obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }

        planetCount++;
    }

    void SecondStep()
    {
        if (planetCount == 13 || planetCount == 19)
        {
            obj = Instantiate(planets.Find(p => p is Sun).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }
        else if (planetCount == 15)
        {
            /*obj = Instantiate(planets.Find(p => p is Bomb).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);*/
        }
        else if (planetCount == 20)
        {
            obj = Instantiate(planets.Find(p => p is Earth).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }
        else
        {
            obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }

        planetCount++;
    }

    void ThirdStep()
    {
        if (planetCount == 22 || planetCount == 26 || planetCount == 29)
        {
            obj = Instantiate(planets.Find(p => p is Earth).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }
        if (planetCount == 25)
        {
            obj = Instantiate(planets.Find(p => p is BlackHole).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(0f, 3f, 0f);
        }
        else
        {
            obj = Instantiate(planets.Find(p => p is CommonPlanet).obj, parent.transform, false);
            obj.transform.localPosition = new Vector3(x[Random.Range(0, x.Length)], 3f, 0f);
        }

        planetCount++;
    }
}
