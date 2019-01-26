using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : Planet
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DeathTimer());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (death && collision.gameObject.tag == "Player")
        {
            GameOver.gameOverManager.StartGameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StopAllCoroutines();
    }
}
