using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomItem : Item
{
    private void Start()
    {
        speed = 2;
        base.Init();
    }
}
