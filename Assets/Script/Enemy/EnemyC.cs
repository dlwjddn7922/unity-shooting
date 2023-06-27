using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : Enemy
{
    public override void Init()
    {
        data.speed = 0.3f;
        data.hp = 15;
        data.fireDelayTime = 3f;

        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}

