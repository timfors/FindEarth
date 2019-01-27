using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool isStay = false;
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player" && !isStay)
        {
            player.transform.SetParent(transform);
            player.GetComponent<PlayerControll>().GetPlanet(player.tag);
            isStay = true;
        }
        else if (player.tag == "arm" && !isStay)
        {
            GameObject.FindGameObjectWithTag("Player").transform.SetParent(transform);
            isStay = true;
            player.GetComponentInParent<PlayerControll>().GetPlanet(player.tag);
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        isStay = false;
    }
}
