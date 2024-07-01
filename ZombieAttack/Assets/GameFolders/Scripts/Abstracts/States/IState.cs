using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.States
{
    public interface IState 
    {
        void OnEnter();
        void OnExit();
        void Tick();
        void FixedTick();
        void LateTick();
    }
}
