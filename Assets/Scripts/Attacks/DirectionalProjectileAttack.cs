using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Projectile;

public class DirectionalProjectileAttack : AttackBehaviour
{
    [SerializeField]
    private ProjectileWeapon ProjectileWeapon;

    public override void DoAttack(Vector3 Location)
    {
        Vector2 Heading = GameManager.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float Distance = Heading.magnitude;
        Vector2 Direction = Heading / Distance;
        print(Direction);

        for (int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
        {
            GameObject projectileObject = Instantiate(ProjectileWeapon.Projectile, Location, Quaternion.Euler(Direction * 360));

            Projectile projectile = projectileObject.AddComponent<Projectile>();

            projectile.Sprite = ProjectileWeapon.Sprite;
            projectile.Speed = ProjectileWeapon.ProjectileSpeed;
            projectile.Direction = Quaternion.Euler(Direction * 360);
            projectile.BaseDamage = ProjectileWeapon.ProjectileDamage;
            projectile.ExtraDamage = ProjectileWeapon.BaseDamage;
            projectile.Penetration = ProjectileWeapon.Penetration;
            projectile.LifeSpan = ProjectileWeapon.ProjectileLifespan;

            projectile.Launch();
        }
    }
}