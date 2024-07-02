using System;
using UnityEngine;
using UnityEngine.UI;
using ZombieAttack.Managers;

namespace ZombieAttack.UIs
{
    public class StartButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        private void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel("GameScene");
        }
    }
}
