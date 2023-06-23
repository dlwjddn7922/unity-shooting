using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletA : MonoBehaviour
{
    public float speed = 5;
    private Enemy e;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void SetEnemy(Enemy enemy)
    {
        e = enemy;
    }
    public void Hit()
    {
        e.DestoryBullet(this);
    }
}
