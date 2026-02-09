using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace ToBeNamed.Character
{
    public class Player : MonoBehaviour, IHurtable
    {
        public int Health;

        public int MaxHealth = 12;

        [SerializeField]
        private float HealthCooldown;

        [SerializeField]
        //[ReadOnly]
        private float HealthCooldownTime;

        [SerializeField]
        //[ReadOnly]
        private List<GameObject> Weapons;

        [SerializeField]
        private Sprite FullHeart, HalfHeart, EmptyHeart;

        [SerializeField]
        private Image[] HeartSlots;

        [SerializeField]
        [Range(0.1f, 10f)]
        private float AttackTime = 5;

        private MainControls PlayerControls;

        private Mouse PlayerMouse;

        private void Start()
        {
            PlayerControls = new MainControls();

            //PlayerControls.PlayerControls.Mouse.performed += OnAttack;

            PlayerMouse = Mouse.current;

            //StartCoroutine(DoAttacks());

            Health = MaxHealth;

            UpdateHealthBar();
        }

        private void OnAttack()
        {
            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<AttackBehaviour>().DoAttack(transform.position);
            }
        }

        private void Update()
        {
            if(HealthCooldownTime > 0)
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

            if(PlayerMouse.leftButton.IsActuated())
            {
                OnAttack();
            }

            for(int i = 0; i < MaxHealth; i++)
            {
            
            }
        }
         
        public void Hurt(int Damage)
        {
            if(HealthCooldownTime == 0)
            {
                Health -= Damage;

                GetComponent<AudioSource>().Play();

                HealthCooldownTime = HealthCooldown;
            }

            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            float fractionalHealth = Health / 2f;

            for(int i = 0; i < 6; i++)
            {
                if(fractionalHealth > i)
                {
                    if (fractionalHealth < i + 1)
                    {
                        HeartSlots[i].sprite = GameManager.Instance.HeartImages[1];
                    }
                    else
                    {
                        HeartSlots[i].sprite = GameManager.Instance.HeartImages[0];
                    }     
                }
                else
                {
                    HeartSlots[i].sprite = GameManager.Instance.HeartImages[2];
                }
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
            yield return new WaitForSeconds(AttackTime);

            foreach (GameObject weapon in Weapons)
            {
                weapon.GetComponent<AttackBehaviour>().DoAttack(transform.position);
            }

            StartCoroutine(DoAttacks());
        }
    }
}