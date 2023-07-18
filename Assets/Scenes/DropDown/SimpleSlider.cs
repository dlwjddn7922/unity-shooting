using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlider : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Slider sd;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnImageChage()
    {
        image.color = new Color(1, 1, 1, sd.value / sd.maxValue);
    }
}
