using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    Text text;
    //Blinking speed
    public float speed;

    void Start()
    {
        text = gameObject.GetComponent<Text>();    
    }
    void Update()
    {
        if (!GlobalConfig.GetGlobalConfig.isPlaying)
        {
            if (text.color.a >= 0.6 || text.color.a <= 0)
            {
                speed *= -1;
            }
            text.color = new Color(text.color.r, text.color.b, text.color.g, text.color.a + speed * Time.deltaTime);
        }
        else
        {
            text.color = new Color(text.color.r, text.color.b, text.color.g, 0);
        }
    }
}
