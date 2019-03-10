using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject planet;

    public void Create()
    {
        if (GlobalConfig.GetGlobalConfig.isReady)
        {
            Instantiate(planet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
