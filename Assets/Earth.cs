using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Planet
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Players"))
        {
            GlobalConfig.GetGlobalConfig.SetPoints(Random.Range(2, 11));
        }
    }
}
