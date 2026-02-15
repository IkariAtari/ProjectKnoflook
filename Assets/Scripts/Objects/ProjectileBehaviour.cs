using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace ToBeNamed.Projectiles
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        public int BaseDamage;

        [SerializeField]
        [ReadOnly]
        private int PenetrationCounter;

        public Projectile Projectile;

        private float speed;
        private float wiggleAmount;
        private float wiggleSpeed;
        private float wiggleSpeedVariance;
        private float wiggleAmountVariance;
        
        private float gravitationalAcceleration;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Projectile.Sprite;
            PenetrationCounter = Projectile.Penetration;
            speed = Projectile.Speed;
            wiggleAmount = Projectile.WiggleAmount;
            wiggleSpeed = Projectile.WiggleSpeed;
            wiggleSpeedVariance = Projectile.WiggleSpeedVariance;
            wiggleAmountVariance = Projectile.WiggleAmountVariance;
        }

        public void Launch()
        {
            StartCoroutine(LifespanTimer());
        }

        private void Update()
        {
            float varianceA = Random.Range(-wiggleAmountVariance, wiggleAmountVariance);
            float varianceS = Random.Range(-wiggleSpeedVariance, wiggleSpeedVariance);

            gravitationalAcceleration += Projectile.GravityStrength;
            
            transform.position += transform.up * speed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, 0f, Mathf.Sin(Time.time * wiggleSpeed * varianceS) * wiggleAmount * varianceA));
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
                        gameObject.SetActive(false);
                    }
                }
            }

            PenetrationCounter--;
        }
    }
}