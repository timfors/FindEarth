using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.position.y < 0)
        {
            if (!collision.gameObject.tag.Equals("Player"))
                Destroy(collision.gameObject);
            else
            {

            }
        }
        else
        {
            if (collision.gameObject.tag.Equals("Player"))
            { }
        }
    }
}
