using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieAttack.Controllers;
using ZombieAttack.Managers;

namespace ZombieAttack.Combats
{
    public class Dead : MonoBehaviour
    {
        [SerializeField] private float delayTime = 20f;

        public void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }
        
        private IEnumerator DeadActionAsync()
        {
            EnemyManager.Instance.RemoveEnemyController(this.GetComponent<EnemyController>());
            yield return new WaitForSeconds(delayTime);
            Destroy(this.gameObject);
        }
    }
}
