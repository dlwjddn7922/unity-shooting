using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMPro.TMP_Text enchanTxt;
    [SerializeField] private GameObject equip;

    public ItemData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetData(ItemData data)
    {
        this.data = data;

        icon.sprite = data.sprite;
        enchanTxt.text = data.enchan.ToString();
        equip.SetActive(data.isEquip);
    }
    
}
