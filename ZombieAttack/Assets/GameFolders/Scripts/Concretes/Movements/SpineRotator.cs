using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.Movements;

namespace ZombieAttack.Movements
{
    public class SpineRotator : IRotator
    {
        private Transform _transform;
        private float _tilt;

        public SpineRotator(Transform transform)
        {
            _transform = transform;
        }
        public void RotationAction(float direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            _tilt = Mathf.Clamp(_tilt - direction, -40, 40);
            _transform.Rotate(new Vector3(0,0,_tilt));
        }
    }
}
