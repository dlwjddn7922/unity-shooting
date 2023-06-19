using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [System.Serializable]
    public class BGData
    {
        public Transform trans;
        public float speed;
    }
    public List<BGData> bgDatas = new List<BGData>();
    /*public Transform[] trans;

    // Start is called before the first frame update
    void Start()
    {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        //���� �����̵�
        //trans[0].Translate(Vector3.down * Time.deltaTime * 6f);
        //trans[1].Translate(Vector3.down * Time.deltaTime * 3f);
        //trans[2].Translate(Vector3.down * Time.deltaTime * 1f);

        /*for (int i = 0; i < trans.Length; i++)
        {
            if(trans[i].localPosition.y <= -11.96f)
            {
                Vector3 vec3 = trans[i].localPosition;
                vec3.y = 11.96f;
                trans[i].localPosition = vec3;
            }
        }*/
        for (int i = 0; i < bgDatas.Count; i++)
        {
            // ���ȭ�� �̵�
            bgDatas[i].trans.Translate(Vector3.down * Time.deltaTime * bgDatas[i].speed);

            //���ȭ���� ȭ�� ������ �̵���
            if(bgDatas[i].trans.localPosition.y <= -11f)
            {
                //���ȭ���� ���� �̵���ǥ�� �̵�
                Vector3 vec = bgDatas[i].trans.localPosition;
                vec.y = 11f; //���� �̵���ǥ
                bgDatas[i].trans.localPosition = vec;
            }
        }
    }
}
