using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    bool follow;

    // Start is called before the first frame update
    void Start()
    {
        follow = false;
        StartCoroutine(CheckPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector3.Distance(new Vector3(player.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)) > 4)
        {
            transform.position = new Vector3(transform.position.x + (player.position.x > transform.position.x? 0.3f : -0.3f), transform.position.y, transform.position.z);
        }*/

        Debug.Log(Vector3.Distance(new Vector3(player.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)));
    }

    IEnumerator CheckPlayer()
    {
        while (true)
        {
            if (!follow && Vector3.Distance(new Vector3(player.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)) >= 6)
            {
                if (player.position.x > 0f)
                {
                    StartCoroutine(ChangeRight());
                    follow = true;
                }
                else if(player.position.x < 0f)
                {
                    StartCoroutine(ChangeLeft());
                    follow = true;
                }
            }

            yield return null;
        }
    }

    IEnumerator ChangeLeft()
    {
        float x = 0f;

        while (x > -12.5f)
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            x -= 0.5f; Debug.Log(x);
            yield return new WaitForSeconds(0.001f);
        }

        follow = false;
        yield return null;
    }

    IEnumerator ChangeRight()
    {
        float x = 0f;

        while (x < 12.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            x += 0.5f; Debug.Log(x);
            yield return new WaitForSeconds(0.001f);
        }

        follow = false;
        yield return null;
    }
}
