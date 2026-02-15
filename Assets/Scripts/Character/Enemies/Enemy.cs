using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = System.Numerics.Quaternion;

namespace Character.Enemies
{
    public class Enemy : MonoBehaviour, IHurtable, IPooledObject
    {
        [SerializeField]
        //[ReadOnly]
        private GameObject Player;

        public float Speed;

        private Vector2 Direction;

        private int Health;

        public int MaxHealth;

        [SerializeField]
        private Slider HealthBar;

        public int Damage;
        
        private AudioSource AudioSource;
        
        [SerializeField] private GameObject DamageNumberPrefab;
        
        public IManagedPool ManagedPool { get; set; }

        private void Start()
        {
            Player = GameObject.Find("Player");

            AudioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            float Step = Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Step);

            if(Health <= 0)
            {
                Destroy(this);
            }
        }

        public void Init(Vector2 position)
        {
            Health = MaxHealth;
            HealthBar.maxValue = MaxHealth;
            HealthBar.value = MaxHealth;

            transform.position = position;
        }

        public void Hurt(int Damage)
        {
            Health -= Damage;
            HealthBar.value = Health;
            AudioSource.pitch = Random.Range(0.8f, 1.2f);
            
            AudioSource.Play();

            DamageNumbers damageNumbers = Instantiate(DamageNumberPrefab, transform).GetComponent<DamageNumbers>();
            damageNumbers.transform.SetParent(null);
            damageNumbers.ShowNumbers(Damage);
            
            if(Health <= 0)
            {
                ManagedPool.Release(this.gameObject);
            }
        }

        private void OnCollisionStay2D(Collision2D Collision)
        {
            if(Collision.transform.tag == "Player")
            {
                Collision.transform.GetComponent<Player>().Hurt(Damage);
            }
        }
    }
}