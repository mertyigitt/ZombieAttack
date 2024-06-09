using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Controllers;

namespace ZombieAttack.Movements
{
    public class MoveWithCharacterController : IMover
    {
        CharacterController _characterController;

        public MoveWithCharacterController(PlayerController playerController)
        {
            _characterController = playerController.GetComponent<CharacterController>();
        }
        public void MoveAction(Vector3 direction, float moveSpeed)
        {
            if(direction.magnitude == 0f) return;
            
            Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
            Vector3 movement = worldPosition * moveSpeed * Time.deltaTime;
            
            _characterController.Move(movement);
        }
    }
}
