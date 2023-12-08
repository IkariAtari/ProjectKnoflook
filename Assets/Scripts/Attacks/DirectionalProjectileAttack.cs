using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToBeNamed.Projectiles;

public class DirectionalProjectileAttack : AttackBehaviour
{
    [SerializeField]
    private ProjectileWeapon ProjectileWeapon;

    public override void DoAttack(Vector3 Location)
    {
        Vector3 MouseLocation = GameManager.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 MouseLocation2D = new Vector2(MouseLocation.x, MouseLocation.y);
        Vector2 Heading = MouseLocation2D - new Vector2(transform.position.x, transform.position.y);
        Heading.Normalize();
        float Distance = Heading.magnitude;
        Vector2 Direction = Heading / Distance;

        //float DirectionAngle = Vector2.Angle(transform.position * Mathf.Rad2Deg, MouseLocation);

        float DirectionAngle = Mathf.Atan2(Heading.x, Heading.y) * Mathf.Rad2Deg;
        Quaternion DirectionAxis = Quaternion.AngleAxis(DirectionAngle, -Vector3.forward);

        for (int i = 0; i < ProjectileWeapon.ProjectileAmount; i++)
        {
            GameObject projectileObject = Instantiate(ProjectileWeapon.Projectile.ProjectilePrefab, Location, DirectionAxis);
            ProjectileBehaviour projectile = projectileObject.AddComponent<ProjectileBehaviour>();

            projectile.BaseDamage = ProjectileWeapon.BaseDamage;
            projectile.Projectile = ProjectileWeapon.Projectile;

            projectile.Launch();
        }
    }
}