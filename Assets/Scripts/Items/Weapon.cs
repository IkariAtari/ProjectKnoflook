using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Items;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 1)]
public class Weapon : Item
{
    public int BaseDamage;
    public int AttackSpeed;
    public int CritRate;
    public int CritDamage;

    public GameObject Prefab;
}