using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.States
{
    public interface IState 
    {
        void Tick();
        void OnEnter();
        void OnExit();
    }
}
