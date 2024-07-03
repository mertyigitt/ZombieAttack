using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZombieAttack.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
        private PlayerInputManager _playerInputManager;
        private int _playerIndex;


        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = prefabs[_playerIndex];
        }
        

        private void OnEnable()
        {
            StartCoroutine(LoadPlayersAsync());
        }

        private IEnumerator LoadPlayersAsync()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
            for (int i = 0; i < GameManager.Instance.PlayerCount; i++)
            {
                _playerInputManager.JoinPlayer(_playerIndex);
                yield return waitForSeconds;
            }
        }

        public void HandleOnJoin()
        {
            _playerIndex++;
            if (_playerIndex >= prefabs.Length) _playerIndex = prefabs.Length - 1;
            _playerInputManager.playerPrefab = prefabs[_playerIndex];
            _playerInputManager.splitScreen = true;
        }
        public void HandleOnLeft()
        {
            _playerIndex--;
            if (_playerIndex < 0) _playerIndex = 0;
            _playerInputManager.playerPrefab = prefabs[_playerIndex];
            _playerInputManager.splitScreen = false;
        }
    }
}
