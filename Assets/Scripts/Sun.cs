using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Planet
{
    public GameObject burnCreate;

    GameObject fire;

    bool death;

    public override bool CheckProbability()
    {
        float p = Random.Range(0f, 1f);

        if (p < probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator DeathTimer()
    {
        float timer = 0f;

        while (timer < 3f)
        {
            timer++;
            yield return new WaitForSeconds(1f);
        }

        death = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "arm")
        {
            StartCoroutine(DeathTimer());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (fire == null)
        {
            fire = Instantiate(burnCreate, player.transform.position, player.transform.rotation);
            fire.transform.SetParent(player.transform);
            fire.transform.localPosition = new Vector3(0, -0.5f, -1.2f);
            fire.transform.localEulerAngles = new Vector3(0, 0, 180);
            fire.transform.localScale = new Vector3(0.4f, 0.3f, 0.3f);
        }

        if (death && collision.gameObject.tag == "Player" || death && collision.gameObject.tag == "arm")
        {
            GameOver.gameOverManager.StartGameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(fire);
        fire = null;
        StopAllCoroutines();
    }
}
