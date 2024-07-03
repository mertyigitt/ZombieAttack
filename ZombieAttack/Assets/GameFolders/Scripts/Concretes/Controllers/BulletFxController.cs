using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Controllers
{
    public class BulletFxController : MonoBehaviour
    {
        [SerializeField] private float maxLifeTime = 5f;
        [SerializeField] private float moveSpeed;

        private Rigidbody _rigidbody;
        private ParticleSystem _particleSystem;
        private float _currentLifeTime;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            _particleSystem.Play();
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            
            if (_currentLifeTime > maxLifeTime)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }
        
        public void SetDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * moveSpeed;
        }
    }
}
