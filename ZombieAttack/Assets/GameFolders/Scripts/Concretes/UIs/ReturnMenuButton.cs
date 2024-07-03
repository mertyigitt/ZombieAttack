using ZombieAttack.Abstracts.UIs;
using ZombieAttack.Managers;

namespace ZombieAttack.UIs
{
    public class ReturnMenuButton : MyButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ReturnMenu();
        }
    }
}
