using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
}
public abstract class Enemy : MonoBehaviour
{
    protected EnemyData data = new EnemyData();

    protected SpriteAnimation sa;
    [SerializeField] protected List<Sprite> nomalSP;
    [SerializeField] protected List<Sprite> hitSP;
    [SerializeField] protected List<Sprite> explosionSP;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * data.speed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerBullet>())
        {
            //삭제될때는 나 자신이 가장 늦게 삭제가 되야한다.
            Destroy(collision.gameObject);
            Hit(collision.GetComponent<PlayerBullet>().power);
        }
    }

    public virtual void Init()
    {
        sa = GetComponent<SpriteAnimation>();
    }
    public void Hit(float dmg)
    {
        sa.SetSprite(nomalSP, hitSP, 0.2f, 0.05f);
        data.hp -= dmg;
        if(data.hp <= 0)
        {

            Dead();
        }
    }
    public void Dead()
    {
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<CircleCollider2D>().isTrigger = false;
        sa.SetSprite(explosionSP, 0.1f, () => Destroy(gameObject));
    }
}
