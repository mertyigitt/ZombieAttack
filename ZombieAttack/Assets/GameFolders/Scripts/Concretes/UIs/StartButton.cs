using System;
using UnityEngine;
using UnityEngine.UI;
using ZombieAttack.Abstracts.UIs;
using ZombieAttack.Managers;

namespace ZombieAttack.UIs
{
    public class StartButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel("GameScene");
        }
    }
}
