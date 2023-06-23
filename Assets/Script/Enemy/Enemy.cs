using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public float speed;
    public float hp;
    public float fireDelayTime;
}
public abstract class Enemy : MonoBehaviour
{
    protected EnemyData data = new EnemyData();

    protected SpriteAnimation sa;
    [SerializeField] protected List<Sprite> nomalSP;
    [SerializeField] protected List<Sprite> hitSP;
    [SerializeField] protected List<Sprite> explosionSP;
    [SerializeField] protected EnemyBulletA bullet;
    

    private Transform firePos;
    private Transform enemyBulletParent;
    private Player p;
    private List<EnemyBulletA> bullets = new List<EnemyBulletA>();
    private float fireTimer;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * data.speed);

        if(p == null)
        {
            p = FindObjectOfType<Player>();
            return;
        }
        else if(firePos != null)
        {
            //타겟을 찾아 방향 전환
            Vector2 vec = transform.position - p.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            firePos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        //미사일 발사
        fireTimer += Time.deltaTime;
        if( fireTimer >= data.fireDelayTime)
        {
            fireTimer = 0;
            EnemyBulletA b = Instantiate(bullet, firePos);
            b.transform.SetParent(enemyBulletParent);
            bullets.Add(b);
            b.SetEnemy(this);
        }
        //화면 밖으로 이동하는 미사일 삭제
       
        if(transform.position.y < -6)
        {
                Destroy(gameObject);
        }

        //화면 밖으로 이동시 삭제
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets.Contains(bullet))
            {
                Destroy(bullets[i].gameObject);
                bullets.RemoveAt(i);
                break;
            }
        }
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
        firePos = transform.GetChild(0);
        p = FindAnyObjectByType<Player>();
        
    }
    public void SetBulletParent(Transform t)
    {
        enemyBulletParent = t;
    }
    public void DestoryBullet(EnemyBulletA bullet)
    {
        for (int i = bullets.Count -1; i >= 0; i--)
        {
            if(bullets.Contains(bullet))
            {
                Destroy(bullets[i].gameObject);
                bullets.RemoveAt(i);
                break;
            }
        }
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
        GetComponent<CircleCollider2D>().enabled = false;
        sa.SetSprite(explosionSP, 0.1f, () => Destroy(gameObject));
    }
}
