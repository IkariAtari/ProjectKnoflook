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

        [SerializeField]
        private int PenetrationCounter;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Sprite;
            PenetrationCounter = Penetration;
        }

        public void Launch()
        {
            StartCoroutine(LifespanTimer());
        }

        private void Update()
        {
            transform.rotation = Direction;
            transform.position += transform.up * Speed * Time.deltaTime;
        }

        private IEnumerator LifespanTimer()
        {
            yield return new WaitForSeconds(LifeSpan);

            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Walls")
            {
                Destroy(this.gameObject);
            }

            if(PenetrationCounter >= 0)
            {
                if(collision.transform.GetComponent<IHurtable>() != null)
                {
                    collision.transform.GetComponent<IHurtable>().Hurt(BaseDamage + ExtraDamage);

                    if(PenetrationCounter == 0)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }

            PenetrationCounter--;
        }
    }
}