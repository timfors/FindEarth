using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GlobalConfig.GetGlobalConfig.record;
        gameObject.GetComponent<Text>().text = "Best score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
