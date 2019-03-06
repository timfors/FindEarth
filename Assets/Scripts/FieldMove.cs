using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    public Transform cam;

    private Vector3 mov = new Vector3(36, 0, 0);  

    void Update()
    {
        if (cam.position.x - transform.position.x >= 18)
        {
            transform.position += mov; 
        }
        else if (cam.position.x - transform.position.x <= -18)
        {
            transform.position -= mov;
        }
    }
}
