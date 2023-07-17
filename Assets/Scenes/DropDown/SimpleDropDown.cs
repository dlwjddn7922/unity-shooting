using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SimpleDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropDown;

    // Start is called before the first frame update
    void Start()
    {
        dropDown.value = 0;
        dropDown.ClearOptions();

        string[] str = { "S class", "A class", "B class", "C class", "D class" };
        List<TMP_Dropdown.OptionData> od = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < str.Length; i++)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = str[i];
            od.Add(data);
        }
        dropDown.options = od;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
