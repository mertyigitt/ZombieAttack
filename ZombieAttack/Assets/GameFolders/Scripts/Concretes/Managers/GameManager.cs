using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZombieAttack.Abstracts.Helpers;

namespace ZombieAttack.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Awake()
        {
            SetSingletonThisGameObject(this);
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(LoadLevelAsync(levelName));
        }
        
        private IEnumerator LoadLevelAsync(string levelName)
        {
            yield return SceneManager.LoadSceneAsync(levelName);
        }
    }
}
