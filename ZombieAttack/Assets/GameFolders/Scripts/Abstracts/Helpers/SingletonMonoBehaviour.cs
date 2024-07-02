using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieAttack.Abstracts.Helpers
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T  Instance { get; private set; }

        protected void SetSingletonThisGameObject(T instance)
        {
            if (Instance is null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
