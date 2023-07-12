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
    [SerializeField] private TMP_Text text;
    float time = 300f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toggles[2].isOn == true)
        {
            time -= Time.deltaTime;
            text.text = $"TIME" +"  "+ time.ToString("0");
        }else
        {
            time = 300f;
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

}
