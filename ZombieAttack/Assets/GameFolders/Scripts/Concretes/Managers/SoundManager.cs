using System;
using UnityEngine;
using ZombieAttack.Abstracts.Helpers;
using ZombieAttack.Controllers;

namespace ZombieAttack.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] AudioClip audioClip;

        private SoundController[] _soundControllers;

        public SoundController[] SoundControllers => _soundControllers;
        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _soundControllers = GetComponentsInChildren<SoundController>();
        }

        private void Start()
        {
            _soundControllers[0].SetClip(audioClip);
            _soundControllers[0].PlaySound(Vector3.zero);
        }
        
        public void RangeAttackSound(AudioClip audioClip, Vector3 position)
        {
            _soundControllers[1].PlaySound(position);
            _soundControllers[1].SetClip(audioClip);
        }
        
        public void MeleeAttackSound(AudioClip audioClip, Vector3 position)
        {
            for (int i = 1; i < _soundControllers.Length; i++)
            {
                if(_soundControllers[i].IsPlaying) continue;
                
                _soundControllers[i].SetClip(audioClip);
                _soundControllers[i].PlaySound(position);
                break;
            }
        }
    }
}
