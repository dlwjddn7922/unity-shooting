using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    [SerializeField] private Image image;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OntoggleMove()
    {
        if (toggle.isOn == true)
        {
            transform.Translate(new Vector3(20f, 0, 0));
            image.color = Color.green;
        }
        if(toggle.isOn == false)
        {
            transform.Translate(new Vector3(-20f, 0, 0));
            image.color = Color.white;
        }
    }
}
