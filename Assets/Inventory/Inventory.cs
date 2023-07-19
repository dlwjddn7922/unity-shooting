using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Weapon,
    Armor,
    Etc
}
public class ItemData
{
    public Sprite sprite;
    public int enchan;
    public bool isEquip;
    public ItemType type;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] private InvenItem prefab;
    [SerializeField] private Transform parent;
    [SerializeField] private Toggle[] toggles;

    //아이템 데이터/////////////////
    string[] keys = { "weapon", "armor", "etc", };
    [SerializeField] List<Sprite> weaponS;
    [SerializeField] List<Sprite> armorS;
    [SerializeField] List<Sprite> etcS;
    /// /////////////////////////////

    
    Dictionary<string, List<ItemData>> itemDic = new Dictionary<string, List<ItemData>>();
    List<InvenItem> invenItems = new List<InvenItem>();
    // Start is called before the first frame update
    void Start()
    {
        CreateData(weaponS, ItemType.Weapon);
        CreateData(armorS, ItemType.Armor);
        CreateData(etcS, ItemType.Etc);
    }

    // Update is called once per frame
    void Update()
    {
        //아이템생성
        if(Input.GetKeyDown(KeyCode.F1))
        {
            string key = keys[Random.Range(0, keys.Length)];
            ItemData data = itemDic[key][Random.Range(0, itemDic[key].Count)];
            InvenItem item = Instantiate(prefab, parent);
            item.SetData(data);

            invenItems.Add(item);
        }
    }
    public void CreateData(List<Sprite> sprites, ItemType type)
    {
        List<ItemData> datas = new List<ItemData>();
        for (int i = 0; i < sprites.Count; i++)
        {
            ItemData data = new ItemData();
            data.sprite = sprites[i];
            data.enchan = 0;
            data.isEquip = false;
            data.type = type;
            datas.Add(data);
        }
        itemDic.Add(keys[(int)type], datas);
    }
    public void OnTabChange(Toggle toggle)
    {
        ItemType type = ItemType.Weapon;
        for (int i = 0; i < toggles.Length; i++)
        {
            if(toggle == toggles[i] && toggle.isOn)
            {
                type = (ItemType)i;

                break;
            }
        }

        for (int i = 0; i < invenItems.Count; i++)
        {
            if(type == invenItems[i].data.type)
            {
                invenItems[i].gameObject.SetActive(true);
            }
            else
            {
                invenItems[i].gameObject.SetActive(false);
            }
        }
    }

}
