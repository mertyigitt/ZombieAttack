using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Helpers;
using ZombieAttack.Controllers;

namespace ZombieAttack.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] private int maxCountOnGame = 50;
        [SerializeField] private List<EnemyController> enemies;

        public List<Transform> Targets { get; private set; }
        public bool CanSpawn => maxCountOnGame > enemies.Count;
        public bool IsListEmpty => enemies.Count <= 0;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemies.Add(enemyController);
        }
        
        public void RemoveEnemyController(EnemyController enemyController)
        {
            enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount();
        }

        public void DestroyAllEnemies()
        {
            foreach (EnemyController enemy in enemies)
            {
                Destroy(enemy.gameObject);                
            }
            enemies.Clear();
        }
    }
}
