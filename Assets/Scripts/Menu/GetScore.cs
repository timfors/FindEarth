using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = GlobalConfig.GetGlobalConfig.points;
        gameObject.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
