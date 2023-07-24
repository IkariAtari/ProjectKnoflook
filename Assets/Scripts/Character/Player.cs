using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace ToBeNamed.Character
{
    public class Player : MonoBehaviour, IHurtable
    {
        public int Health;

        public int MaxHealth = 12;

        [SerializeField]
        private float HealthCooldown;

        [SerializeField]
        [ReadOnly]
        private float HealthCooldownTime;

        [SerializeField]
        [ReadOnly]
        private List<GameObject> Weapons = new List<GameObject>();

        [SerializeField]
        private Weapon WeaponToAdd;

        [SerializeField]
        private Sprite FullHeart, HalfHeart, EmptyHeart;

        [SerializeField]
        private Image[] HeartImages;

        [Button("AddWeapon")]
        private void ButtonAddWeapon()
        {
            if (WeaponToAdd != null)
            {
                AddWeapon(WeaponToAdd);
            }
        }

        [Button("ClearWeapon")]
        private void ButtonClearWeapons()
        {
            Weapons.Clear();
        }

        [SerializeField]
        [Range(1f, 10f)]
        private float AttackTime = 5;

        private void Start()
        {
            StartCoroutine(DoAttacks());

            Health = MaxHealth;
        }

        private void Update()
        {
            if(HealthCooldownTime != 0)
            {
                HealthCooldownTime--;
            }
            else
            {
                HealthCooldownTime = 0;
            }

            if(Health < 0)
            {
                Health = 0;
            }

            for(int i = 0; i < MaxHealth; i++)
            {
            
            }
        }
         
        public void Hurt(int Damage)
        {
            print("Player Hurted");

            if(HealthCooldownTime == 0)
            {
                Health -= Damage;

                HealthCooldownTime = HealthCooldown;
            }
        }

        public void AddWeapon(Weapon Weapon)
        {
            GameObject weapon = Instantiate(Weapon.Prefab);
            weapon.transform.SetParent(transform);

            Weapons.Add(weapon);
        }

        private IEnumerator DoAttacks()
        {
            print("Attack!");

            yield return new WaitForSeconds(AttackTime);

            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<AttackBehaviour>().DoAttack(transform.position);
            }

            StartCoroutine(DoAttacks());
        }
    }
}