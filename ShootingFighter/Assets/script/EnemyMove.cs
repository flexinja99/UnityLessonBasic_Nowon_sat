using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 dir = Vector3.forward;
    public float speed = 5f;
    Transform tr;

    private void Awake() =>
        tr = GetComponent<Transform>();

    private void FixedUpdate() => tr.Translate(dir * speed * Time.fixedDeltaTime);











}
