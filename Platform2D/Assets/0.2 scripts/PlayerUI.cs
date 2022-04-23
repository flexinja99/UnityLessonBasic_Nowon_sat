using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    [SerializeField] private Slider hpBar;


    public void SetHPBar(float value) =>
        hpBar.value = value;
}
