using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed;

    public Vector3 movement;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movement * speed * Time.deltaTime);        
    }
}
