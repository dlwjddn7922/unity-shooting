using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleToggle : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles;
    [SerializeField] private Image image;
    //[SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {
        
        //Invoke("ToggleAllOff", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void OnToggleChange(Toggle toggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] == toggle && toggle.isOn == true)
            {
                Debug.Log(toggles[i].gameObject.name);
                //image.color = toggle.GetComponent<ToggleColor>().color;
                
            }
        }
        

    }

    void ToggleAllOff()
    {
        foreach (var toggle in toggles)
        {
            toggle.isOn = false;
        }
    }
}
