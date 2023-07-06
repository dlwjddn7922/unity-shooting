using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    bool isStrat = false;
    [HideInInspector] public float power;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
       transform.Translate(Vector3.up * Time.deltaTime * 6f);
        if(transform.position.y > Camera.main.orthographicSize + 0.2f)
        {
            OnHide();
        }
        
    }
    public void OnShow()
    {
        gameObject.SetActive(true);
        Vector2 pos = transform.localPosition;
        pos .y = - Camera.main.orthographicSize;
        transform.localPosition = pos;
        isStrat = true;
    }
    public void OnHide()
    {
        gameObject.SetActive(false);
        isStrat = false;
    }
}
