using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOverManager;

    [SerializeField]
    List<GameObject> fields;

    private void Awake()
    {
        gameOverManager = this;
    }

    public void StartGameOver()
    {
        GlobalConfig.GetGlobalConfig.SetRecord();
        StartCoroutine(GameOverSteps());
    }

    IEnumerator GameOverSteps()
    {
        /*int t = 1;
        while (t > 1)
        {
            t--;
            yield return new WaitForSeconds(1);
        }*/

        GlobalConfig.GetGlobalConfig.start = false;

        Destroy(GameObject.FindWithTag("Player"));

        while (Camera.main.transform.position.y > -20f)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 0.2f, -20f);
            yield return new WaitForSeconds(0.001f);
        }

        foreach (GameObject field in fields)
        {
            field.SetActive(false);
        }

        StartMenu.GetMenu.ChangeToGOver();
    }

    public void ClearGenerators()
    {
        foreach (GameObject field in fields)
        {
            field.SetActive(true);
            field.transform.position = field.GetComponentInChildren<PlanetGenerator>().parentStartPos;
            field.GetComponentInChildren<PlanetGenerator>().Clear();
        }
    }
}
