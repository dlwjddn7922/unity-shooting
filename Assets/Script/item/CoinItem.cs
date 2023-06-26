using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : Item
{
    private void Start()
    {
        speed = 0.5f;
        base.Init();
    }

}
