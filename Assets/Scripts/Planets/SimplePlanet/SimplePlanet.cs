using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlanet : MonoBehaviour
{
    [SerializeField]
    private PlanetData planetData;

    [SerializeField]
    private GameEvent onCollided;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onCollided.Raise();
        }
    }
}
