using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Projectile;

public class CircleDanmaku : AttackBehaviour
{
    private ProjectileWeapon ProjectileWeapon;

    private void Start()
    {
        ProjectileWeapon = base.Weapon as ProjectileWeapon;
    }

    public override void DoAttack(Vector3 Location)
    {
        for(int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
        {
            float dir = (360 / ProjectileWeapon.ProjectileAmount) * i;

            Quaternion direction =  Quaternion.AngleAxis(dir, Vector3.forward);

            GameObject projectileObject = Instantiate(ProjectileWeapon.Projectile, Location, direction);

            Projectile projectile = projectileObject.GetComponent<Projectile>();

            projectile.Speed = ProjectileWeapon.ProjectileSpeed;
            projectile.Direction = direction;
            projectile.BaseDamage = ProjectileWeapon.ProjectileDamage;
            projectile.ExtraDamage = ProjectileWeapon.BaseDamage;
            projectile.Penetration = ProjectileWeapon.Penetration;
        }
    }
}