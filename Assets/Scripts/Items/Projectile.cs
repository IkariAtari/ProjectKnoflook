using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicProjectile", menuName = "Projectiles/BasicProjectile", order = 1)]
public class Projectile : ScriptableObject
{
    public int Penetration;
    public int Damage;
    public float Speed;
    public float Lifespan;
    public float WiggleAmount;
    public float WiggleSpeed;
    public float WiggleSpeedVariance;
    public float WiggleAmountVariance;
    public float GravityStrength;

    public Sprite Sprite;
    public GameObject ProjectilePrefab;
}
