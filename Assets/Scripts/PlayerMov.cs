using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0, 1, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalConfig.GetGlobalConfig.start)
        {
            transform.Translate(movement * GlobalConfig.GetGlobalConfig.speed * Time.deltaTime);
        }
    }
}
