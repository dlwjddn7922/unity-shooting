using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBullet : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public float power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
