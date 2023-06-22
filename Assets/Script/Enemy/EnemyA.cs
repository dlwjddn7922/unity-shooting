using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public override void Init()
    {
        data.speed = 0.5f;
        data.hp = 10;

        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
