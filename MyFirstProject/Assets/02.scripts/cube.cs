using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public int a = 3;
    public Transform tr;
    Vector3 move;

    private void Awake()
    {
        Debug.Log(this);
        Debug.Log(this.gameObject);
        Debug.Log(gameObject);
        tr = this.gameObject.GetComponent<Transform>();
        tr = gameObject.GetComponent<Transform>();
        tr = GetComponent<Transform>();
        tr = transform;

    }
    // Start is called before the first frame update
    void Start()
    {
        tr.position = Vector3.zero;
        transform.position = Vector3.zero;
        GetComponent<Transform>().position = Vector3.zero;
        gameObject.GetComponent<Transform>().position = Vector3.zero;
        this.gameObject.GetComponent<Transform>().position = Vector3.zero;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizaintal");
        float v = Input.GetAxis("vertical");
        Debug.Log($"h={h}, v={v}");
        move = new Vector3(h, 0, v);
    } 

        // Update is called once per frame
        void FixedUpdate()
        {
         //position ���ͽÿ���
         //position �� �����Ӵ� ��ȭ���� �����־���Ѵ�.
         // �Ÿ� ��ȭ��(�ӵ�) =�Ÿ�/�ð�
         // ������ �ð� �� ��ġ ��ȭ��(������ ���� �ӵ�) = ��ġ/�����ӽð�
         // ��ġ ��ȭ�� = ������ �ð��� ��ġ ��ȭ�� * ������ �ð�

         tr.position += move * Time.fixedDeltaTime;

        }
}

