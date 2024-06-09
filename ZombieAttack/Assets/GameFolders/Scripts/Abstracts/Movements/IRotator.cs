using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.Movements
{
    public interface IRotator
    {
        void RotationAction(float direction, float speed);
    }
}
