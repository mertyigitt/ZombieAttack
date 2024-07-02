using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ZombieAttack.Managers;

namespace ZombieAttack.UIs
{
    public class DisplayWaveLevel : MonoBehaviour
    {
        private TMP_Text _levelText;

        private void Awake()
        {
            _levelText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnNextWave += HandleOnNextWave;
        }

        private void HandleOnNextWave(int levelValue)
        {
            _levelText.text = levelValue.ToString();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnNextWave -= HandleOnNextWave;
        }
    }
}
