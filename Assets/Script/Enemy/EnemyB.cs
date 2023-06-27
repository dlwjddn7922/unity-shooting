using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    public override void Init()
    {
        data.speed = 0.5f;
        data.hp = 20;
        data.fireDelayTime = 2f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

}
