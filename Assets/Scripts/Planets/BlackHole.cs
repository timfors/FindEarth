using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            target.transform.SetParent(transform);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            target.transform.localScale /= 1.2f;
            if (target.transform.localScale.x < 0.10)
            {
                Destroy(target.gameObject);
            }
        }
    }
}