using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    public override void Init()
    {
        data.speed = 0.1f;
        data.hp = 30;
        data.fireDelayTime = 5f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

}
