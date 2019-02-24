using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    private bool founded = false;

    [SerializeField]
    private float normalSpeed;

    [SerializeField]
    private float fastSpeed;

    private float speed;


    private void Start()
    {
        speed = fastSpeed;
    }

    public void SearchingForPlayer()
    {
        StopAllCoroutines();
        StartCoroutine(Rotating());
    }

    IEnumerator Rotating()
    {
        yield return null;
        gameObject.transform.Rotate(new Vector3(0, 0, -1) * speed);
        SearchingForPlayer();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            speed = normalSpeed;
            collision.transform.parent = gameObject.transform;
            collision.transform.localEulerAngles = new Vector3(0, 0, 270);
        }
    }
   
    public void StopRotate()
    {
        speed = fastSpeed;
        StopAllCoroutines();
    }
}
