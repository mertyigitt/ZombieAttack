using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Abstracts.States;

namespace ZombieAttack.States
{
    public class StateTransformer 
    {
        public IState To { get;}
        public IState From { get;}
        public Func<bool> Condition { get;}

        public StateTransformer(IState to, IState from, Func<bool> condition)
        {
            To = to;
            From = from;
            Condition = condition;
        }
    }
}
