using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Controllers;

namespace ZombieAttack.Animation
{
    public class CharacterAnimation
    {
        private Animator _animator;

        public CharacterAnimation(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if(_animator.GetFloat("moveSpeed") == moveSpeed) return;
            _animator.SetFloat("moveSpeed", moveSpeed, 0.1f , Time.deltaTime);
        }
    }
}
