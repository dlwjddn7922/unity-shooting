using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Sprite> center;
    [SerializeField] private List<Sprite> left;
    [SerializeField] private List<Sprite> right;
    [SerializeField] private PlayerBullet bullet;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletParent;
    enum Direction //애니메이션의 상태값
    {
        Center,
        Left,
        Right
    }
    public float speed;
    public float bulletSpeed;
    private Direction dir = Direction.Center;
    public float fireDelayTime;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(center,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        // 키보드 좌우 화살표 왼쪽과 오른쪽의 값을 가지고 온다. (-1~1)
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        // 키보드 상하 화살표 위족과 아래쪽의 값을 가지고 온다.(-1~1)
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        
        // 좌표의 최댓값과 최소값을 지정하여 그이상 이하로는 못움지기게 하는 함수
        float clampX = Mathf.Clamp(transform.position.x + x, -2.5f, 2.5f);
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);

        transform.position = new Vector3(clampX, clampY, 0f);
        //가만있을시 애니메이션
        if(x == 0  && dir != Direction.Center)
        {
            dir = Direction.Center;
            GetComponent<SpriteAnimation>().SetSprite(center, 0.2f);
        }//오른쪽으로 이동시 애니메이션
        else if(x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            GetComponent<SpriteAnimation>().SetSprite(right, 0.2f);
        }//왼쪽으로 이동시 애니메이션
        else if(x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            GetComponent<SpriteAnimation>().SetSprite(left, 0.2f);
        }

        fireTimer += Time.deltaTime;
        if(fireTimer >= fireDelayTime)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                //게임오브젝트를 생성시키는함수
                PlayerBullet b = Instantiate(bullet, parent);
                b.speed = bulletSpeed;
                b.name = "pBullet";
                b.transform.SetParent(bulletParent);
                fireTimer = 0;
                Destroy(b.gameObject, 2f);
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerBullet>())
        {
            Destroy(collision.gameObject);
        }
        if (collision.transform.GetComponent<EnemyA>())
        {
            Destroy(gameObject);
        }
    }
}
