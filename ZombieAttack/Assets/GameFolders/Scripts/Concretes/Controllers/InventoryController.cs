using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private WeaponController[] weapons;

        private Animator _animator;
        
        public WeaponController CurrentWeapon { get; private set; }

        private byte _index;


        private void Awake()
        {
            weapons = GetComponentsInChildren<WeaponController>();
            _animator = GetComponentInChildren<Animator>();
            foreach (WeaponController weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
        }

        private void Start()
        {
            CurrentWeapon = weapons[_index];
            CurrentWeapon.gameObject.SetActive(true);
        }
        
        public void ChangeWeapon()
        {
            _index++;

            if (_index >= weapons.Length)
            {
                _index = 0;
            }

            CurrentWeapon = weapons[_index];

            foreach (WeaponController weapon in weapons)
            {
                if (CurrentWeapon == weapon)
                {
                    weapon.gameObject.SetActive(true);
                    _animator.runtimeAnimatorController = CurrentWeapon.AnimatorOverrideController;
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
                
               
            }
        }
    }
}
