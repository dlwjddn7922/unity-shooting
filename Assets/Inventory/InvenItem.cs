using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
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
        enchanTxt.text = data.enchan.ToString("+0");
        equip.SetActive(data.isEquip);
    }
    public void OnClick()
    {
        Debug.Log(data.index);
    }
    //drag
    Vector2 pos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       pos = GetComponent<RectTransform>().anchoredPosition += eventData.delta;
    }

    public void OnDrag(PointerEventData eventData)
    {
        pos = GetComponent<RectTransform>().anchoredPosition += eventData.delta;

    }
}
