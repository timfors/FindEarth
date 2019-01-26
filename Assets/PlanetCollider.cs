using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCollider : MonoBehaviour
{
    public GameObject point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(GetComponent<Collider2D>().Distance());
            Debug.Log(collision.gameObject.transform.GetChild(1).GetComponent<Collider2D>().IsTouching(GetComponent<Collider2D>()));
            //point.transform.position = new Vector3(collision.transform.localPosition.x, , -1f);
        }
    }
}
