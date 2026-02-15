using System;
using System.Collections;
using System.Collections.Generic;
using Character.Enemies;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

//using Sirenix.OdinInspector;

namespace ToBeNamed.Worldgen
{
    public class EnemySpawner : MonoBehaviour, IManagedPool
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

        [SerializeField] private int MaxEnemies;

        private int Time;

        public GameObject Enemy;

        [SerializeField]
        //[ReadOnly]
        private bool PlayerIsInRange;
        
        private ObjectPool<GameObject> pool;

        public void Release(GameObject gameObject)
        {
            pool.Release(gameObject);
        }
        
        private void Awake()
        {
            pool = new ObjectPool<GameObject>(
                createFunc: CreateEnemy,
                actionOnGet: OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: OnDestroy,
                collectionCheck: true,
                defaultCapacity: 10,
                maxSize: 150
                );
        }

        private GameObject CreateEnemy()
        {
            GameObject enemy = Instantiate(Enemy);
            enemy.GetComponent<IPooledObject>().ManagedPool = this;
            enemy.GetComponent<Enemy>().Init(transform.position.AsVector2() + Random.insideUnitCircle.normalized * SpawnRadius);
                
            return enemy;
        }

        private void OnGet(GameObject gameObject)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<Enemy>().Init(transform.position.AsVector2() + Random.insideUnitCircle.normalized * SpawnRadius);
        }

        public void OnRelease(GameObject gameObject)
        {
            print("Released");
            gameObject.SetActive(false);
        }

        private void OnDestroy(GameObject gameObject)
        {
            Destroy(gameObject);
        }

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
                    if (pool.CountActive >= MaxEnemies)
                    {
                        print("Too many enemies");
                    }
                    else
                    {
                        GameObject enemy = pool.Get();
                    }
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