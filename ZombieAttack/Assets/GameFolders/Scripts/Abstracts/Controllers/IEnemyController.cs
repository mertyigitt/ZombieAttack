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
        public IMover Mover { get;}
        public InventoryController Inventory { get;}
        public CharacterAnimation Animation { get;}
        public Dead Dead { get;}
        public Transform Target { get; set; }
        public float Magnitude { get;}
    }
}
