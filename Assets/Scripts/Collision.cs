using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            player.transform.SetParent(transform);
            player.GetComponent<PlayerControll>().GetPlanet(player.tag);
        }
        else if (player.tag == "arm")
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(transform);
            player.GetComponentInParent<PlayerControll>().GetPlanet(player.tag);
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
