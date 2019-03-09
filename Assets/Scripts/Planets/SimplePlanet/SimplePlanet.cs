using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlanet : MonoBehaviour
{

    [SerializeField]
    private PlanetData planetData;

    private int speed;

    [SerializeField]
    private GameEvent onCollided;

    private void Start()
    {
        speed = planetData.Speed;
    }

    private void Awake()
    {
        StartMovement();
        Destroy(gameObject, 10);
    }

    public void SetHighSpeed()
    {
        if (!GlobalConfig.GetGlobalConfig.isPlaying)
        {
            speed = planetData.FastSpeed;
        }
    }

    void StartMovement()
    {
        StopAllCoroutines();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GlobalConfig.GetGlobalConfig.isPlaying)
        {
            collision.transform.parent = transform;
            onCollided.Raise();
        }
    }
}
