using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;
    [SerializeField] private TMP_Text txt;
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
        //txt.fontSize = 70;
    }
}
