using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Projectiles;

public class CircleDanmaku : AttackBehaviour
{
    [SerializeField]
    private ProjectileWeapon ProjectileWeapon;

    public override void DoAttack(Vector3 Location)
    { 
        for(int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
        {
            float dir = (360 / ProjectileWeapon.ProjectileAmount) * i;

            Quaternion direction =  Quaternion.AngleAxis(dir, Vector3.forward);

            //projectile.Launch();
        }
    }
}