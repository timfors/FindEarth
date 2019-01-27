using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector3(0, 1, 0);
        StartCoroutine(Anim());
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalConfig.GetGlobalConfig.start)
        {
            gameObject.GetComponent<Rigidbody2D>().drag -= (0.2f * Time.deltaTime);
            transform.Translate(movement * GlobalConfig.GetGlobalConfig.speed * Time.deltaTime);
        }
    }

    IEnumerator Anim()
    {
        while (!GlobalConfig.GetGlobalConfig.start)
        {
            yield return null;
        }

        GetComponent<Animator>().SetTrigger("jump");

        yield return null;
    }
}
