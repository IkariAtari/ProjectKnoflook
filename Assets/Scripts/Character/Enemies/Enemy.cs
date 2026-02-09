using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ToBeNamed.Character.Enemies
{
    public class Enemy : MonoBehaviour, IHurtable
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

        private void Start()
        {
            Player = GameObject.Find("Player");
            
            AudioSource = GetComponent<AudioSource>();

            Health = MaxHealth;
            HealthBar.maxValue = MaxHealth;
            HealthBar.value = MaxHealth;
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

        public void Hurt(int Damage)
        {
            Health -= Damage;

            HealthBar.value = Health;
            
            AudioSource.pitch = Random.Range(0.8f, 1.2f);
            
            AudioSource.Play();

            if(Health <= 0)
            {
                Destroy(this.gameObject);
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