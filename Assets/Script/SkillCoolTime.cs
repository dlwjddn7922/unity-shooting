using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    [SerializeField] private Image timerImg;
    [SerializeField] private TMP_Text timertxt;
    [SerializeField] public float maxTime = 6;
    float curTimer = 0;
    bool isSkillStart = false;
    // Update is called once per frame
    void Update()
    {
        if (isSkillStart)
        {
            curTimer += Time.deltaTime;
            timerImg.fillAmount = curTimer / maxTime;
            if (maxTime - curTimer <= 1)
                timertxt.text = $"{(maxTime - curTimer):N1}";
            else
                timertxt.text = (maxTime - (int)curTimer).ToString();

            if (curTimer >= maxTime)
            {
                isSkillStart = false;
                timerImg.gameObject.SetActive(false);
                timertxt.gameObject.SetActive(false);
            }
        }
    }
    public void OnStart()
    {
        if (isSkillStart == true)
            return;
        isSkillStart = true;

        curTimer = 0;
        timerImg.fillAmount = 0;
        timertxt.text = maxTime.ToString();
        timerImg.gameObject.SetActive(true);
        timertxt.gameObject.SetActive(true);
    }
}

