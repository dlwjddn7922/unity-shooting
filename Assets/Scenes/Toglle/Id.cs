using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Id : MonoBehaviour
{
    [SerializeField] private TMP_Text idText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnIdCheck()
    {
        if(idText.text == "dlwjddn7922")
        {
            Debug.Log("Correct Id");
        }
    }
}
