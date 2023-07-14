using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Naver : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private GameObject[] gameObjects;
    //[SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text[] timeText;
    float time = 300f;
    Button button;
    float timer = 180;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (toggles[2].isOn == true)
        {
            time -= Time.deltaTime;
            timeText[0].text = ((int)time / 60 % 60).ToString()+ "M";
            timeText[1].text = ((int)time % 60).ToString() + "S";
        }
        else
        {
            time = 300f;
        }*/
        //시간설정
        timer -= Time.deltaTime;

        System.TimeSpan span = System.TimeSpan.FromSeconds(timer);
        Debug.Log($"m:{span.Minutes}, s:{span.Seconds}");
    }
    public void OnToggleChange(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                Debug.Log(toggles[i].gameObject.name);
                gameObjects[i].SetActive(true);
                break;

            }
            if (toggles[i] == toggle && toggle.isOn == false)
            {
                Debug.Log(toggles[i].gameObject.name);
                gameObjects[i].SetActive(false);
                break;
            }
        }
    }
    public void NowTime()
    {
        
    }

}
