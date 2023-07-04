using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    [SerializeField] private TMP_Text txt;
    [SerializeField] private Image hpimage;
    [SerializeField] private TMP_Text hptxt;
    [SerializeField] private Image mpimage;
    [SerializeField] private TMP_Text mptxt;
    [SerializeField] private Image coolImage;
    [SerializeField] private TMP_Text coolText;
    float curHp = 100;
    float maxHp = 100;
    float curMp = 100;
    float maxMp = 100;
    float cooltime = 6.0f;
    float filltime = 1.0f;
    float setTime = 6.0f;
    bool isStart = false;

    int score;
    public int SetScore
    {
        get { return score; }
        set
        {
            score = value;
            txt.text = $"Score=" + " " + value.ToString();
        }
    }

    private void Start()
    {
        instance = this;
        float value = curHp / maxHp;
        hpimage.fillAmount = value;
        hptxt.text = $"{(int)(value * 100f)} / {maxHp}";
        value = curMp / maxMp;
        mpimage.fillAmount = value;
        mptxt.text = $"{(int)(value * 100f)} / {maxMp}";
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            if(Random.Range(0,10) < 5)
            {
                curHp += Random.Range(5, 10);
            }
            else
            {
                curHp -= Random.Range(5, 10);
            }
            float value = curHp / maxHp;
            hpimage.fillAmount = value;
            hptxt.text = $"{(int)(value * maxHp)} / {maxHp}";
        }
        if (Input.GetKey(KeyCode.F2))
        {
            if (Random.Range(0, 10) < 5)
            {
                curMp += Random.Range(5, 10);
            }
            else
            {
                curMp -= Random.Range(5, 10);
            }
            float value = curMp / maxMp;
            mpimage.fillAmount = value;
            mptxt.text = $"{(int)(value * maxMp)} / {maxMp}";
        }
        if (Input.GetKey(KeyCode.X))
        {
           isStart = true;
        }
        if(isStart == true)
        {
            float value = cooltime - (filltime * Time.deltaTime);    
            coolImage.fillAmount += (cooltime -value) / 6;
            if (setTime > 1)
            {
                setTime -= Time.deltaTime;
                coolText.text = setTime.ToString("0");
            }else
            {
                setTime -= Time.deltaTime;
                coolText.text = setTime.ToString("0.0");
            }
            if (coolImage.fillAmount >= 1)
            {
                coolImage.fillAmount = 0;
                coolText.text = 6.ToString("6");
                setTime = 6.0f;
                isStart = false;
            }
            
        }

    }
}
