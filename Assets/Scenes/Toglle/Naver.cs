using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Naver : MonoBehaviour
{
    [SerializeField] private Toggle autoLoginToggle;
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text[] timeText;
    [SerializeField] private Text timetext;
    [SerializeField] private TMP_InputField inputID;
    [SerializeField] private TMP_InputField inputPW;
    float time = 300f;
    Button button;
    float timer = 300f;
    private string id = "qwer";
    private string pw = "1234";

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("autoLogin"))
        {
            autoLoginToggle.isOn = bool.Parse(PlayerPrefs.GetString("autoLogin"));
        }
        else
        {
            autoLoginToggle.isOn = false;
        }
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
        //Debug.Log($"m:{span.Minutes}, s:{span.Seconds}");
        //\n = 줄바꾸기
        if(toggles[2].isOn == true)
        {
           timetext.text = $"남은시간\n<b><color=green>{span.Minutes}분 {span.Seconds}초</color></b>";
        }
        else
        {
            timer = 300f;
        }


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
    public void OnLogin()
    {
        if(string.IsNullOrEmpty(inputID.text))
        {
            Debug.Log("아이디가 입력되지 않음");
            return;
        }
        if (string.IsNullOrEmpty(inputPW.text))
        {
            Debug.Log("비밀번호가 입력되지 않음");
            return;
        }
        if(inputID.text != id)
        {
            Debug.Log("잘못된 아이디입니다.");
            return;
        }
        if (inputPW.text != pw || inputPW.text.Length < 4)
        {
            Debug.Log("잘못된 비밀번호입니다.");
            return;
        }
        if (inputID.text == id && inputPW.text == pw)
        {
            Debug.Log("로그인 성공!.");
            return;
        }
        
    }
    public void OnAutoLogin(Toggle toggle)
    {
        PlayerPrefs.SetString("autoLogin", toggle.isOn.ToString());
    }
}
