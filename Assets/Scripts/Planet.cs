using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject obj;
    public int start;
    public float probability;

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (Time.deltaTime * 1f), transform.localPosition.z);
    }

    public virtual bool CheckProbability()
    {
        return true;
    }
}
