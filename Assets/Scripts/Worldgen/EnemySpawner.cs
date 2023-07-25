using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;

namespace ToBeNamed.Worldgen
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject Player;

        [SerializeField]
        private float SpawnRadius;

        [SerializeField]
        [Range(0.1f, 10000f)]
        private int TimerMax;

        [SerializeField]
        [Range(1f, 100f)]
        private int SpawnAmount;

        private int Time;

        public GameObject Enemy;

        [SerializeField]
        //[ReadOnly]
        private bool PlayerIsInRange;

        private void Start()
        {
            Time = TimerMax;
        }

        private void Update()
        {
            if (Enemy == null)
            {
                return;
            }

            if (PlayerIsInRange)
            {
                if (Time == TimerMax)
                {
                    DoSpawn();
                }

                if(Time > 0f)
                {
                    Time--;
                }
                else
                {
                    Time = TimerMax;   
                }
            }
        }

        private void FixedUpdate()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, SpawnRadius, LayerMask.GetMask("Player"));

            if (collider == null)
            {
                PlayerIsInRange = false;
            }

            else if (collider.transform.tag == "Player")
            {
                PlayerIsInRange = true;
            }
        }

        private void DoSpawn()
        {
            for(int i = 0; i < SpawnAmount; i++)
            {
                GameObject enemy = Instantiate(Enemy, transform.position.AsVector2() + Random.insideUnitCircle * SpawnRadius, Quaternion.identity);
            }
        }

        private void OnDrawGizmos()
        {
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, SpawnRadius);
        }
    }
}