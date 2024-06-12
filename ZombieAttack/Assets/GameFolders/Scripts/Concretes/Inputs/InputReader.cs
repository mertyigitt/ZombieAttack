using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using ZombieAttack.Abstracts.Inputs;

namespace ZombieAttack.Inputs
{
    public class InputReader : MonoBehaviour , IInputReader
    {
        private int _index;
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }
        public bool IsAttackButtonPressed { get; private set; }
        public bool IsInventoryButtonPressed { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, 0f, oldDirection.y);
        }
        
        public void OnRotate(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            IsAttackButtonPressed = context.ReadValueAsButton();
        }

        public void OnInventoryPressed(InputAction.CallbackContext context)
        {
            if(IsInventoryButtonPressed && context.action.triggered) return;

            StartCoroutine(WaitOneFrameAsync());
        }

        IEnumerator WaitOneFrameAsync()
        {
            IsInventoryButtonPressed = true && _index % 2 == 0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
            _index++;
        }
    }
}
