using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using ZombieAttack.Abstracts.Helpers;
using ZombieAttack.Controllers;

namespace ZombieAttack.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] private int waveLevel = 1;
        [SerializeField] private int maxWaveBoundaryCount = 50;
        [SerializeField] float waveMultiple = 1.2f;
        [SerializeField] private float waitNextLevel = 10f;
        
        private int _currentWaveMaxCount = 100;
        public bool IsWaveFinished => _currentWaveMaxCount <= 0;

        public event Action<int> OnNextWave;
        
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        private void Start()
        {
            _currentWaveMaxCount = maxWaveBoundaryCount;
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(LoadLevelAsync(levelName));
        }
        
        public void DecreaseWaveCount()
        {
            if(IsWaveFinished)
            {
                if (EnemyManager.Instance.IsListEmpty)
                {
                    StartCoroutine(StartNextWaveAsync());
                }
            }
            else
            {
                _currentWaveMaxCount--;
            }
        }
        
        private IEnumerator LoadLevelAsync(string levelName)
        {
            yield return SceneManager.LoadSceneAsync(levelName);
        }
        
        private IEnumerator StartNextWaveAsync()
        {
            yield return new WaitForSeconds(waitNextLevel);
            maxWaveBoundaryCount = Convert.ToInt32(maxWaveBoundaryCount * waveMultiple);
            _currentWaveMaxCount = maxWaveBoundaryCount;
            waveLevel++;
            OnNextWave?.Invoke(waveLevel);
        }
    }
}
