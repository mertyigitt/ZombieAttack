using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Controllers;

namespace ZombieAttack.Movements
{
    public class RotatorYCharacter : IRotator
    {
        private Transform _transform;
        private float _tilt;

        public RotatorYCharacter(PlayerController playerController)
        {
            _transform = playerController.TurnTransform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -30, 30);
            _transform.localRotation = Quaternion.Euler(_tilt,0f,0f);
        }
    }
}
