using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePlanet : Planet
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
}
