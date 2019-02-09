using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    bool isStay = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.transform.SetParent(transform);
            player.transform.localPosition = new Vector3(0, 4f, 0);
            player.transform.rotation = Quaternion.identity;
            player.GetComponent<PlayerControll>().GetPlanet();
            isStay = true;
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        isStay = false;
    }
}
