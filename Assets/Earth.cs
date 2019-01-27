using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Planet
{
    bool steal;

    private void Start()
    {
        steal = false;
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("arm"))
        {
            if (!steal)
            {
                GlobalConfig.GetGlobalConfig.SetPoints(Random.Range(2, 11));
                steal = true;
            }
        }
    }
}
