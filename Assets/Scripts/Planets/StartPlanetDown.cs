using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlanetDown : MonoBehaviour
{
    void Update()
    {
        if (GlobalConfig.GetGlobalConfig.isPlaying)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - (Time.deltaTime * GlobalConfig.GetGlobalConfig.speed), transform.localPosition.z);

            if (transform.position.y <= -18f)
                Destroy(this.gameObject);
        }
    }
}
