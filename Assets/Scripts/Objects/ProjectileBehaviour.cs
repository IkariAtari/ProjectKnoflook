using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToBeNamed.Projectiles
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public int BaseDamage;

        [SerializeField]
        private int PenetrationCounter;

        public Projectile Projectile;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Projectile.Sprite;
            PenetrationCounter = Projectile.Penetration;
        }

        public void Launch()
        {
            StartCoroutine(LifespanTimer());
        }

        private void Update()
        {
            //transform.rotation = Direction;
            transform.position += transform.up * Projectile.Speed * Time.deltaTime;
        }

        private IEnumerator LifespanTimer()
        {
            yield return new WaitForSeconds(Projectile.Lifespan);

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
                    collision.transform.GetComponent<IHurtable>().Hurt(BaseDamage + Projectile.Damage);

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