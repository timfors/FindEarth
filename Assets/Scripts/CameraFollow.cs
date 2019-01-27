using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow GetFollow;

    public Transform player;

    bool follow;

    private void Awake()
    {
        GetFollow = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        follow = false;
        StartCoroutine(CheckPlayer());
    }

    IEnumerator CheckPlayer()
    {
        while (true)
        {
            if (player == null)
                yield return null;
            else
            {
                if (!follow && Vector3.Distance(new Vector3(player.position.x, 0, 0), new Vector3(transform.position.x, 0, 0)) >= 6)
                {
                    if (GlobalConfig.GetGlobalConfig.right)
                    {
                        StartCoroutine(ChangeRight());
                        follow = true;
                    }
                    else if (GlobalConfig.GetGlobalConfig.left)
                    {
                        StartCoroutine(ChangeLeft());
                        follow = true;
                    }

                    yield return new WaitForSeconds(1f);
                }

                yield return null;
            }
        }
    }

    IEnumerator ChangeLeft()
    {
        float x = 0f;

        while (x > -12.5f)
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            x -= 0.5f;
            yield return new WaitForSeconds(0.001f);
        }

        follow = false;

        //yield return new WaitForSeconds(1f);
        gameObject.GetComponentInChildren<SwapField>().ChangeLeftPlatform();

        yield return null;
    }

    IEnumerator ChangeRight()
    {
        float x = 0f;

        while (x < 12.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            x += 0.5f;
            yield return new WaitForSeconds(0.001f);
        }

        follow = false;

        //yield return new WaitForSeconds(1f);  
        gameObject.GetComponentInChildren<SwapField>().ChangeRightPlatform();

        yield return null;
    }
}
