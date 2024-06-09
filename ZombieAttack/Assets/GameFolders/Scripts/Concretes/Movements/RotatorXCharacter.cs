using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Controllers;

namespace ZombieAttack.Movements
{
    public class RotatorXCharacter : IRotator
    {
        private PlayerController _playerController;

        public RotatorXCharacter(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void RotationAction(float direction, float speed)
        {
            _playerController.transform.Rotate(Vector3.up * direction * speed * Time.deltaTime);
        }
    }
}
