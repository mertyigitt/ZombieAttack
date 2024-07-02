using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GetComponent<CapsuleCollider>().enabled = false;
            yield return new WaitForSeconds(delayTime);
            Destroy(this.gameObject);
        }
    }
}
