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
    protected int weaponTimer;

    private void Start()
    {
        print("Started a weapon");
    }

    public virtual void DoAttack(Vector3 Location)
    {
        if (weaponTimer <= 0)
        {
            weaponTimer = Weapon.AttackSpeed;
        }
        else
        {
            weaponTimer--;
        }
    }
}