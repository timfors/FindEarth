using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	public float speed;
	Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0, 1, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
