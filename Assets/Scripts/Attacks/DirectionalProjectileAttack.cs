using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectiles;
using Random = UnityEngine.Random;
using Objects;

namespace Attacks
{
    public class DirectionalProjectileAttack : AttackBehaviour
    {
        private ProjectileWeapon ProjectileWeapon;

        public override void DoAttack(Vector3 location)
        {
            ProjectileWeapon = (ProjectileWeapon)Weapon;
            base.DoAttack(location);

            if (weaponTimer <= 0)
            {
                Vector3 mouseLocation = GameManager.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouseLocation2D = new Vector2(mouseLocation.x, mouseLocation.y);
                Vector2 heading = mouseLocation2D - new Vector2(location.x, location.y);
                float distance = heading.magnitude;
                Vector2 direction = heading / distance;

                float directionAngle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;
                float angleOffset = ProjectileWeapon.Spread / (float)ProjectileWeapon.ProjectileAmount;

                for (int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
                {
                    GameObject projectileObject = Instantiate(ProjectileWeapon.Projectile.ProjectilePrefab, location,
                        Quaternion.Euler(0f, 0f,
                            directionAngle - 90f + (angleOffset * i) - ProjectileWeapon.Spread / 2f));

                    ProjectileBehaviour projectile = projectileObject.GetComponent<ProjectileBehaviour>();

                    int damageNoise = Random.Range(-1, 5);

                    projectile.BaseDamage = ProjectileWeapon.BaseDamage + damageNoise;
                    projectile.Projectile = ProjectileWeapon.Projectile;

                    projectile.Launch();
                }
            }
        }
    }
}