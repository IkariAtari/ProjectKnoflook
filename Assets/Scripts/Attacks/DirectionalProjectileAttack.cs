using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Projectiles;

public class DirectionalProjectileAttack : AttackBehaviour
{
    private ProjectileWeapon ProjectileWeapon;
    
    public override void DoAttack(Vector3 Location)
    {
        ProjectileWeapon = (ProjectileWeapon)Weapon;
        base.DoAttack(Location);

        if (weaponTimer <= 0)
        {
            Vector3 MouseLocation = GameManager.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            Vector2 MouseLocation2D = new Vector2(MouseLocation.x, MouseLocation.y);

            Vector2 Heading = MouseLocation2D - new Vector2(Location.x, Location.y);

            float Distance = Heading.magnitude;

            Vector2 Direction = Heading / Distance;
            
            float DirectionAngle = Mathf.Atan2(Heading.y, Heading.x) * Mathf.Rad2Deg;

            print(ProjectileWeapon);
            
            float angleOffset = ProjectileWeapon.Spread / (float)ProjectileWeapon.ProjectileAmount;
            
            for (int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
            {
                print(DirectionAngle);
                
                GameObject projectileObject = Instantiate(ProjectileWeapon.Projectile.ProjectilePrefab, Location, Quaternion.Euler(0f, 0f, DirectionAngle - 90f + (angleOffset * i) - ProjectileWeapon.Spread / 2f));
                
                ProjectileBehaviour projectile = projectileObject.AddComponent<ProjectileBehaviour>();

                projectile.BaseDamage = ProjectileWeapon.BaseDamage;
                projectile.Projectile = ProjectileWeapon.Projectile;

                projectile.Launch();
            }
        }
    }
}