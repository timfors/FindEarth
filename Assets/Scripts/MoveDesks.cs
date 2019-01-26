using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDesks : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(new Vector3(cam.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)) > 10){
            transform.position = new Vector3(transform.position.x + (transform.position.x > cam.position.x ? -18 : 18), transform.position.y, transform.position.z);
        }
    }
}
