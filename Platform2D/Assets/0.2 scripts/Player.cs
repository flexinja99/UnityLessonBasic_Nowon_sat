using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerController controller;

    public bool invisiable;
    public float hpMax = 100;
    private float _hp;

    public float hp
    {
        set
        {
            //hp가 깎였을때
            if (_hp > value)
            {
                if (invisiable)
                    return;
                // 아니면 1초 무적
                invisiable = true;
                invoke("InvisiableOff", 1f);
            }
            else if (value <= 0)
            {

            }

            _hp = value;
            ui.SetHPBar(_hp / hpMax);
        }
        get
        {
            return _hp;
        }
    }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        hp = hpMax;
    }
}
