using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.Inputs
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 Rotation { get; }
        bool IsAttackButtonPressed { get;}
        public bool IsInventoryButtonPressed { get;}
    }
}
