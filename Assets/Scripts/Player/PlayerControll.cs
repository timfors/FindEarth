using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject createDust;

    Animator anim;

    GameObject dust;

    public bool isArm;

    public bool isGrounded;

    Transform oldParent;

    public GameObject createFly;

    GameObject fly;

    PlayerMov movement;

    public void GetPlanet(string tag)
    {
        anim.SetBool("jump", false);
        gameObject.GetComponent<Rigidbody2D>().drag = 100000;
        GetComponent<Animator>().SetTrigger("vomit");
        if (tag == "arm")
        {
            isArm = true;
        }
        isGrounded = true;
        movement.enabled = false;
        if (dust == null)
        {
            dust = Instantiate(createDust, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            dust.transform.SetParent(transform);
            dust.transform.localPosition = new Vector3(0, 0.04f, -1);
            dust.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        }
        Destroy(fly);
        fly = null;
    }
    void Start()
    {
        fly = GameObject.FindGameObjectWithTag("Fly");
        anim = gameObject.GetComponent<Animator>();
        movement = gameObject.GetComponent<PlayerMov>();
        oldParent = transform.parent;
        isGrounded = false;
        isArm = false;

        StartMenu.GetMenu.AddCommand(this);
        CameraFollow.GetFollow.player = transform;
    }

    public void OnClick()
    {
        if (isGrounded)
        {
            anim.SetBool("jump", true);
            gameObject.GetComponent<Rigidbody2D>().drag = 1.8f;
            GetComponent<Animator>().SetTrigger("jump");
            transform.parent = oldParent;
            isGrounded = false;
            movement.enabled = true;
            if (!isArm)
            {
                transform.eulerAngles = new Vector3(0, 0, 180 + transform.eulerAngles.z);
            }
            isArm = false;
            if (fly == null)
            {
                fly = Instantiate(createFly, transform.position, transform.rotation);
                fly.transform.SetParent(transform);
                fly.transform.localScale = new Vector3(1, 1, 1);
                fly.transform.localPosition = new Vector3(0, -0.06f, 0);
            }
            Destroy(dust);
            dust = null;
        }
    }

    private void OnDestroy()
    {
        GameOver.gameOverManager.StartGameOver();
    }
}
