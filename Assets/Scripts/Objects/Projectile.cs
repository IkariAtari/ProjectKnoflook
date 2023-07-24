using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToBeNamed.Projectile
{
    public class Projectile : MonoBehaviour
    {
        public float Speed;

        public Quaternion Direction;

        public Sprite Sprite;

        public float LifeSpan;

        public int Penetration;

        public int BaseDamage;

        public int ExtraDamage;

        private int PenetrationCounter;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Sprite;

            StartCoroutine(LifespanTimer());

            PenetrationCounter = Penetration;
        }

        private void Update()
        {
            transform.rotation = Direction;
            transform.position += transform.up * Speed * Time.deltaTime;
        }

        private IEnumerator LifespanTimer()
        {
            yield return new WaitForSeconds(LifeSpan);

            print("Destroyed Projectile");

            Destroy(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(PenetrationCounter >= 0)
            {
                if(collision.transform.GetComponent<IHurtable>() != null)
                {
                    collision.transform.GetComponent<IHurtable>().Hurt(BaseDamage + ExtraDamage);
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            PenetrationCounter--;
        }
    }
}