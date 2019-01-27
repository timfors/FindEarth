using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSound : MonoBehaviour
{
    Transform player;
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sound = gameObject.GetComponent<AudioSource>();
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        sound.volume /= Vector3.Distance(transform.position, player.position) / 20;
    }
}
