using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ZombieAttack.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private bool canFire;
        [SerializeField] private float attackMaxDelay = 0.25f;
        [SerializeField] private Camera camera;
        [SerializeField] private float distance = 100f;
        [SerializeField] private LayerMask layerMask;

        private float _currentTime;

        private void Update()
        {
            _currentTime += Time.deltaTime;

            canFire = _currentTime > attackMaxDelay;
        }
        
        public void Attack()
        {
            if (!canFire) return;

            Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
            {
                Debug.Log(hit.collider.gameObject.name);
                
            } ;
            _currentTime = 0f;
        }
    }
}
