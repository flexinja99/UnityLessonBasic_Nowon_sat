using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    Transform tr;

    private void Awake() => tr= GetComponent<Transform>();
    

    private void FixedUpdate() => tr.Translate(dir * speed * Time.fixedDeltaTime);

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go != null) return;

        if (go.layer == LayerMask.NameToLayer("Enemy"))
        {
            go.GetComponent<Enemy>().DoDestroyEffect();
            Destroy(go);
            Destroy(gameObject);
        }
    }

}
