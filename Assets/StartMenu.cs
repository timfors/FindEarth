using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    GameObject camera;

    [SerializeField]
    Text title;

    [SerializeField]
    Text tap;

    [SerializeField]
    Button touch;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownMenu());
    }

    public void StartGame()
    {
        StopAllCoroutines();
        title.color = new Color(1f, 1f, 1f, 0f);
        tap.color = new Color(1f, 1f, 1f, 0f);
        GlobalConfig.GetGlobalConfig.start = true;
    }

    IEnumerator DownMenu()
    {
        while (camera.transform.position.y > 0)
        {
            camera.transform.position = new Vector3(0, camera.transform.position.y - 0.1f, -20f);
            yield return new WaitForSeconds(0.01f);
        }

        while (title.color.a < 1f)
        {
            title.color = new Color(title.color.r, title.color.g, title.color.b, title.color.a + 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        while (tap.color.a < 1f)
        {
            tap.color = new Color(tap.color.r, tap.color.g, tap.color.b, tap.color.a + 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        touch.interactable = true;

        StartCoroutine(FlashTap());
    }

    IEnumerator FlashTap()
    {
        while (tap.color.a > 0.5f)
        {
            tap.color = new Color(tap.color.r, tap.color.g, tap.color.b, tap.color.a - 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        while (tap.color.a < 1f)
        {
            tap.color = new Color(tap.color.r, tap.color.g, tap.color.b, tap.color.a + 0.01f);
            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(FlashTap());
        yield return null;
    }
}
