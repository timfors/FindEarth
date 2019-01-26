using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(new Vector3(player.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)) > 4)
        {
            transform.position = new Vector3(transform.position.x + (player.position.x > transform.position.x? 0.3f : -0.3f), transform.position.y, transform.position.z);
        }
    }
}
