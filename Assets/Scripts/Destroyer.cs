using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GlobalConfig.GetGlobalConfig.start)
        {
            if (collision.transform.position.y < 0)
            {
                if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("arm"))
                {
                    if (collision.gameObject.GetComponent<PlayerControll>() != null)
                    {
                        GameOver.gameOverManager.StartGameOver();
                    }
                    else
                    {
                        Destroy(collision.gameObject);
                    }
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
