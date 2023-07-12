using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private FollowerBullet bullet;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletParent;

    public float fireDelayTime;
    public float bulletSpeed;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireDelayTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //게임오브젝트를 생성시키는함수
                FollowerBullet b = Instantiate(bullet, parent);
                b.speed = bulletSpeed;
                b.name = "fBullet";
                b.power = 5;
                b.transform.SetParent(bulletParent);
                fireTimer = 0;
                Destroy(b.gameObject, 2f);
            }
        }
    }
}
