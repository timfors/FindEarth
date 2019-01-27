using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject obj;
    public int start;
    public float speed;
    public float probability;


    float rAxis;
    private void Awake()
    {
        rAxis = Random.Range(1, 3);
    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (Time.deltaTime * 1f), transform.localPosition.z);
        transform.Rotate(Vector3.forward * Time.deltaTime * speed * (rAxis == 1 ? 1 : -1));
    }

    public virtual bool CheckProbability()
    {
        return true;
    }
}
