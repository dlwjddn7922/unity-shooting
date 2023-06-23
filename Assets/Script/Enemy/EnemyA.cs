using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    public override void Init()
    {
        data.speed = 2f;
        data.hp = 10;
        data.fireDelayTime = 0.8f;

        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
