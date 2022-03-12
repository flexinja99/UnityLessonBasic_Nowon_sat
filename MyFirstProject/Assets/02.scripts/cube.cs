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
         //position 변셩시에는
         //position 의 프레임당 변화량을 더해주어야한다.
         // 거리 변화량(속도) =거리/시간
         // 프레임 시간 당 위치 변화량(프레임 단위 속도) = 위치/프레임시간
         // 위치 변화량 = 프레임 시간당 위치 변화량 * 프레임 시간

         tr.position += move * Time.fixedDeltaTime;

        }
}

