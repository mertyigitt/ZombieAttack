using UnityEngine;
using UnityEngine.UI;

namespace ZombieAttack.Abstracts.UIs
{
    public abstract class MyButton : MonoBehaviour
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

        protected abstract void HandleOnButtonClicked();

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
    }
}
