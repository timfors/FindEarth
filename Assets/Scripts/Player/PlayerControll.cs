using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject createDust;

    Animator anim;

    GameObject dust;

    public bool isGrounded;

    PlayerMov movement;

    public void GetPlanet(string tag)
    {
        anim.SetBool("jump", false);
        gameObject.GetComponent<Rigidbody2D>().drag = 100000;
        GetComponent<Animator>().SetTrigger("vomit");
        isGrounded = true;
        movement.enabled = false;
        if (dust == null)
        {
            dust = Instantiate(createDust, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            dust.transform.SetParent(transform);
            dust.transform.localPosition = new Vector3(0, 0.04f, -1);
            dust.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        }
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        movement = gameObject.GetComponent<PlayerMov>();
        isGrounded = false;

    }

    public void OnClickLeft()
    {
        if (isGrounded)
        {
            transform.eulerAngles = new Vector3(0, 0, 30);
            anim.SetBool("jump", true);
            gameObject.GetComponent<Rigidbody2D>().drag = 1.8f;
            GetComponent<Animator>().SetTrigger("jump");
            transform.parent = null;
            isGrounded = false;
            movement.enabled = true;
            Destroy(dust);
            dust = null;
        }
    }

    public void OnClickRight()
    {
        if (isGrounded)
        {
            transform.eulerAngles = new Vector3(0, 0, -30);
            anim.SetBool("jump", true);
            gameObject.GetComponent<Rigidbody2D>().drag = 1.8f;
            GetComponent<Animator>().SetTrigger("jump");
            transform.parent = null;
            isGrounded = false;
            movement.enabled = true;
            Destroy(dust);
            dust = null;
        }
    }

    private void OnDestroy()
    {
    }
}
