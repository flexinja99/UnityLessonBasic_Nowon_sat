using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform tr;
    Vector3 move;
    public float speed = 1f;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("vertical");
        move = new Vector3(h, 0, v);
    }

    private void FixedUpdate()
    {
        tr.Translate(move * speed * Time.fixedDeltaTime);
    }






}

