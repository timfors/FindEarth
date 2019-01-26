using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject createDust;

    GameObject dust;

    public bool isArm;

    public bool isGrounded;

    Transform oldParent;

    public GameObject createFly;

    GameObject fly;

    PlayerMov movement;

    public void GetPlanet(string tag)
    {
        GetComponent<Animator>().SetTrigger("idle");
        if (tag == "arm")
        {
            isArm = true;
        }
        isGrounded = true;
        movement.enabled = false;
        dust = Instantiate(createDust, transform.position, transform.rotation);
        dust.transform.SetParent(transform);
        dust.transform.localPosition = new Vector3(0, 0.04f, 0);
        dust.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        Destroy(fly);
    }
    void Start()
    {
        movement = gameObject.GetComponent<PlayerMov>();
        oldParent = transform.parent;
        isGrounded = false;
        isArm = false;
    }

    public void OnClick()
    {
        if (isGrounded)
        {
            GetComponent<Animator>().SetTrigger("jump");
            transform.parent = oldParent;
            isGrounded = false;
            movement.enabled = true;
            if (!isArm)
            {
                transform.eulerAngles = new Vector3(0, 0, 180 + transform.eulerAngles.z);
            }
            isArm = false;
            fly = Instantiate(createFly, transform.position, transform.rotation);
            fly.transform.SetParent(transform);
            fly.transform.localScale = new Vector3(1, 1, 1);
            fly.transform.localPosition = new Vector3(0, -0.06f, 0);
        }
    }
}
