using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public static StartMenu GetMenu;

    [SerializeField]
    GameObject camera;

    [SerializeField]
    GameObject mainMenuField;

    [SerializeField]
    GameObject gameOverField;

    [SerializeField]
    GameObject title;

    [SerializeField]
    Text gTitle;

    [SerializeField]
    Text tap;

    [SerializeField]
    Text gTap;

    [SerializeField]
    Button touch;

    [SerializeField]
    Button gTouch;

    [SerializeField]
    Image icon;

    [SerializeField]
    Text points;

    [SerializeField]
    Text pField;

    [SerializeField]
    Text rField;

    [SerializeField]
    Text record;

    [SerializeField]
    Text pointsNow;

    [SerializeField]
    GameObject startPref;

    bool flashStop;

    private void Awake()
    {
        GetMenu = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownMenu());
    }

    public void StartGame()
    {
        StopAllCoroutines();
        tap.color = new Color(1f, 1f, 1f, 0f);
        title.SetActive(false);
        GlobalConfig.GetGlobalConfig.start = true;
        icon.gameObject.SetActive(true);
        points.gameObject.SetActive(true);
        points.text = "0";
    }

    internal void AddCommand(PlayerControll controll)
    {
        touch.onClick.RemoveAllListeners();
        touch.onClick.AddListener(() => StartGame());
        touch.onClick.AddListener(() => controll.OnClick());
    }

    public void UpdatePoints()
    {
        points.text = GlobalConfig.GetGlobalConfig.points.ToString();
    }

    public void ChangeToGOver()
    {
        touch.interactable = false;
        touch.gameObject.SetActive(false);
        mainMenuField.SetActive(false);
        gameOverField.SetActive(true);
        gameOverField.transform.localPosition = new Vector3(0f, 0f, 0f);
        gTitle.color = new Color(1f, 1f, 1f, 0f);
        gTap.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(GameOverWindow());
    }

    public void RestartGame()
    {
        gTouch.interactable = false;
        gTouch.gameObject.SetActive(false);

        Camera.main.transform.position = new Vector3(0f, 0f, -20f);
        gameOverField.transform.localPosition = new Vector3(0f, 0f, 0f);

        mainMenuField.SetActive(true);
        icon.gameObject.SetActive(false);
        points.gameObject.SetActive(false);
        mainMenuField.transform.localPosition = new Vector3(600f, mainMenuField.transform.localPosition.y, mainMenuField.transform.localPosition.z);

        StartCoroutine(SwapLeft());
    }

    IEnumerator DownMenu()
    {
        while (camera.transform.position.y > 0)
        {
            camera.transform.position = new Vector3(0, camera.transform.position.y - 0.1f, -20f);
            yield return new WaitForSeconds(0.01f);
        }

        title.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        while (tap.color.a < 1f)
        {
            tap.color = new Color(tap.color.r, tap.color.g, tap.color.b, tap.color.a + 0.03f);
            yield return new WaitForSeconds(0.001f);
        }

        touch.gameObject.SetActive(true);
        touch.interactable = true;

        StartCoroutine(FlashTap(tap));
    }

    IEnumerator FlashTap(Text tap)
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

        if (flashStop)
        {
            flashStop = false;
            yield break;
        }

        StartCoroutine(FlashTap(tap));
        yield return null;
    }

    IEnumerator GameOverWindow()
    {
        while (gTitle.color.a < 1f)
        {
            gTitle.color = new Color(gTitle.color.r, gTitle.color.g, gTitle.color.b, gTitle.color.a + 0.005f);
            yield return new WaitForSeconds(0.001f);
        }

        pointsNow.text = GlobalConfig.GetGlobalConfig.points.ToString();

        while (pointsNow.color.a < 1f)
        {
            pField.color = new Color(pField.color.r, pField.color.g, pField.color.b, pField.color.a + 0.008f);
            pointsNow.color = new Color(pointsNow.color.r, pointsNow.color.g, pointsNow.color.b, pointsNow.color.a + 0.008f);
            yield return new WaitForSeconds(0.001f);
        }

        record.text = GlobalConfig.GetGlobalConfig.record.ToString();

        while (record.color.a < 1f)
        {
            rField.color = new Color(rField.color.r, rField.color.g, rField.color.b, rField.color.a + 0.008f);
            record.color = new Color(record.color.r, record.color.g, record.color.b, record.color.a + 0.008f);
            yield return new WaitForSeconds(0.001f);
        }

        while (gTap.color.a < 1f)
        {
            gTap.color = new Color(gTap.color.r, gTap.color.g, gTap.color.b, gTap.color.a + 0.008f);
            yield return new WaitForSeconds(0.001f);
        }

        gTouch.gameObject.SetActive(true);
        gTouch.interactable = true;

        StartCoroutine(FlashTap(gTap));
    }

    IEnumerator SwapLeft()
    {
        GameObject obj = Instantiate(startPref, Vector3.zero, Quaternion.identity);
        obj.transform.position = new Vector3(12.5f, 0f, 0f);

        while (mainMenuField.transform.position.x > 0f)
        {
            mainMenuField.transform.position = new Vector3(mainMenuField.transform.position.x - 0.1f, mainMenuField.transform.position.y, mainMenuField.transform.position.z);
            gameOverField.transform.position = new Vector3(gameOverField.transform.position.x - 0.1f, gameOverField.transform.position.y, gameOverField.transform.position.z);
            obj.transform.position = new Vector3(obj.transform.position.x - 0.1f, obj.transform.position.y, obj.transform.position.z);

            yield return new WaitForSeconds(0.001f);
        }

        gameOverField.SetActive(false);
        gTitle.color = new Color(1f, 1f, 1f, 0f);
        pField.color = new Color(1f, 1f, 1f, 0f);
        pointsNow.color = new Color(1f, 1f, 1f, 0f);
        rField.color = new Color(1f, 1f, 1f, 0f);
        record.color = new Color(1f, 1f, 1f, 0f);
        gTap.color = new Color(1f, 1f, 1f, 0f);

        flashStop = true;

        GameOver.gameOverManager.ClearGenerators();

        StartCoroutine(DownMenu());
        yield return null;
    }
}
