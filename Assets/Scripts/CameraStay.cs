﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 4.5f, -20);
    }
}
