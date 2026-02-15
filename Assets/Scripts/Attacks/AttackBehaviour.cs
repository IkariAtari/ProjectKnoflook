using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Sirenix.Serialization;

public class AttackBehaviour : MonoBehaviour
{
    [SerializeField] public Weapon Weapon;

    [ShowInInspector]
    [ReadOnly]
    protected float weaponTimer;

    private void Start()
    {
        print("Started a weapon");
    }

    public virtual void DoAttack(Vector3 Location)
    {
        if (weaponTimer <= 0f)
        {
            weaponTimer = Weapon.AttackSpeed;
        }
        else
        {
            weaponTimer -= 1f * Time.deltaTime;
        }
    }
}