using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonPlanet : Planet
{
    [SerializeField]
    List<Sprite> sprites;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];
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
}
