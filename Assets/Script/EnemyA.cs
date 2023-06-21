using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 3f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "pBullet")
        {
            //삭제될때는 나 자신이 가장 늦게 삭제가 되야한다.
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
    
}
