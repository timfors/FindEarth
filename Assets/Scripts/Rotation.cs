using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int speed;
    public Vector3 rotate;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime * speed * (Random.Range(1, 2) == 1 ? 1 : -1));
    }
}
