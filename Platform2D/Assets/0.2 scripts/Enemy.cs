using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyController controller;

    public EnemyUI ui;
    public float hpMax = 100;
    private float _hp;

    public float hp
    {
        set
        {
            if (value < 0)
            {
                controller. ChangeEnemyState(EnemyState.Hurt)
            }
            else if (value <=0)
            {

            }

            _hp=value;
            ui.SetHPBar(_hp / hpMax);
        }    
        get
        {
            return _hp;
        }
    }
    public float damage;
    public Vector2 knockbackForce;
    public float knockbackTime;
    
    
        
    


    private void Awake()
    {
        controller = GetComponent<EnemyController>();
        hp = hpMax;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Player>.hp -= damage;
            collision.gameObject.GetComponent <PlayerController>().knockback(new Vector2(knockbackForce.x * controller )
        }
    }
}
