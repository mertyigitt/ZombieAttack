using UnityEngine;
using ZombieAttack.Controllers;

namespace ZombieAttack.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner Info",menuName = "Combat/Spawner Info/Create New", order = 51)]
    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] private EnemyController enemyPrefab;
        [SerializeField] private float maxSpawnTime = 15f;
        [SerializeField] private float minSpawnTime = 3f;

        public EnemyController EnemyPrefab => enemyPrefab;
        public float RandomSpawnMaxTime => Random.Range(minSpawnTime, maxSpawnTime);
    }
}
