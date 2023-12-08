using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicProjectile", menuName = "Projectiles", order = 1)]
public class Projectile : ScriptableObject
{
    public int Penetration;
    public int Damage;
    public float Speed;
    public float Lifespan;

    public Sprite Sprite;
    public GameObject ProjectilePrefab;
}
