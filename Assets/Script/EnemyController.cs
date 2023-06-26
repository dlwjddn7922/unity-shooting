using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyA enemy;
    [SerializeField] private Transform parent;
    [SerializeField] protected Transform enemyBulletParent;

    [SerializeField] private BoxCollider2D spawnBox;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomPosition", 0.5f,1f);
    }

    void RandomPosition()//랜덤스폰
    {
        Vector3 pos = parent.localPosition;

        float sizeX = spawnBox.bounds.size.x;
        float sizeY = spawnBox.bounds.size.y;

        sizeX = Random.Range((sizeX / 2) * -1, sizeX / 2);//양수 음수 전부 가져가는식
        sizeY = Random.Range((sizeY / 2) * -1, sizeY / 2);
        Vector3 randomPos = new Vector3(sizeX, sizeY, 0f);

        Vector3 randPos = pos + randomPos;
        Enemy e = Instantiate(enemy,randPos,Quaternion.identity,parent);
        e.SetBulletParent(enemyBulletParent);

        
    }
}
