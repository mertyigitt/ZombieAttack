using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ZombieAttack.Abstracts.UIs;
using ZombieAttack.Managers;

namespace ZombieAttack.UIs
{
    public class PlayerAddButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }
}
