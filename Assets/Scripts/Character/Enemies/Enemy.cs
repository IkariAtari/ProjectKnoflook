using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ToBeNamed.Character.Enemies
{
    public class Enemy : MonoBehaviour, IHurtable
    {
        [SerializeField]
        //[ReadOnly]
        private GameObject Player;

        public float Speed;

        private Vector2 Direction;

        public int Health;

        private void Start()
        {
            Player = GameObject.Find("Player");
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
        }

        private void OnTriggerStay2D(Collider2D Collision)
        {
            if(Collision.transform.tag == "Player")
            {
                Collision.GetComponent<Player>().Hurt(1);
            }
        }
    }
}