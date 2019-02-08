using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAppear : MonoBehaviour
{
    public float waitBeforeDisapear;

    public float appearSpeed;

    public float disappearSpeed;

    bool showed = false; 

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        StartCoroutine(OpacityIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        //После запуска игры и определенного времени, текст уходит в бок и плотность становится равна 0
        if (GlobalConfig.GetGlobalConfig.isPlaying && showed)
        {
            StartCoroutine(WaitAndDisapear());
        }
        //Если игра не начата или окончена  , то появляется текст
        else if (!GlobalConfig.GetGlobalConfig.isPlaying && !showed)
        {
            StartCoroutine(OpacityIncrease());
            showed = true;
        }
    }

    IEnumerator OpacityIncrease()
    {
        yield return new WaitForSeconds(0.01f);
        if (text.color.a < 0.7)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.g, text.color.a + appearSpeed);
            yield return OpacityIncrease();
        }
    }

    IEnumerator WaitAndDisapear()
    {
        yield return new WaitForSeconds(waitBeforeDisapear);
        Disapear();
    }

    void Disapear()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * disappearSpeed);
        if (transform.localPosition.x <= -250)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            showed = false;
            text.color = new Color(text.color.r, text.color.g, text.color.g, 0);
        }
    }
}
