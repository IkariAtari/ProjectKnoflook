using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ProjectileWeapon", menuName = "Items/ProjectileWeapon", order = 1)]
public class ProjectileWeapon : Weapon
{
    public int ProjectileAmount;
    public int Spread;

    public Projectile Projectile;
}