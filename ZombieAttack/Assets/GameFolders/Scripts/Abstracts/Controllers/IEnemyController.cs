using UnityEngine;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Combats;
using ZombieAttack.Controllers;

namespace ZombieAttack.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get;}
        InventoryController Inventory { get;}
        CharacterAnimation Animation { get;}
        Dead Dead { get;}
        Transform Target { get; set; }
        float Magnitude { get;}
        void FindNearestTarget();
    }
}
