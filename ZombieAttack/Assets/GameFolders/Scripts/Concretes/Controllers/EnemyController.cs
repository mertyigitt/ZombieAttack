using UnityEngine;
using UnityEngine.AI;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Combats;
using ZombieAttack.Managers;
using ZombieAttack.Movements;
using ZombieAttack.States;
using ZombieAttack.States.EnemyStates;

namespace ZombieAttack.Controllers
{
    public class EnemyController : MonoBehaviour , IEnemyController
    {
        [SerializeField] private Transform playerPrefab;
        private IHealth _health;
        NavMeshAgent _navMeshAgent;
        private bool _canAttack;
        private StateMachine _stateMachine;

        public bool CanAttack => Vector3.Distance(Target.position, this.transform.position) <=
            _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        public IMover Mover { get; private set; }
        public InventoryController Inventory { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public Dead Dead { get; private set; }
        public Transform Target { get; set; }
        public float Magnitude => _navMeshAgent.velocity.magnitude;

        private void Awake()
        {
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
            Dead = GetComponent<Dead>();
            
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            FindNearestTarget();

            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);
            
            _stateMachine.AddState(chaseState,attackState,() => CanAttack);
            _stateMachine.AddState(attackState,chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);
            
            _stateMachine.SetState(chaseState);
        }


        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }

        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }
        
        public void FindNearestTarget()
        {
            Transform nearest = EnemyManager.Instance.Targets[0];
            foreach (Transform target in EnemyManager.Instance.Targets)
            {
                float nearstValue = Vector3.Distance(nearest.position, this.transform.position);
                float newValue = Vector3.Distance(target.position, transform.position);
                if (newValue < nearstValue)
                {
                    nearest = target;
                }
            }
            Target = nearest;
        }
    }
}
