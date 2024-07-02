using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Managers;
using ZombieAttack.ScriptableObjects;

namespace ZombieAttack.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private SpawnInfoSO spawnInfo;
        float _currentTime = 0f;
        private float _maxTime;

        private void Start()
        {
            _maxTime = spawnInfo.RandomSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > _maxTime && EnemyManager.Instance.CanSpawn && !GameManager.Instance.IsWaveFinished)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            EnemyController enemyController = Instantiate(spawnInfo.EnemyPrefab, transform.position, Quaternion.identity, transform);
            EnemyManager.Instance.AddEnemyController(enemyController);
            _currentTime = 0f;
            _maxTime = spawnInfo.RandomSpawnMaxTime;
        }
    }
}
