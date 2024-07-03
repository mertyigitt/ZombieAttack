using UnityEngine;
using ZombieAttack.Abstracts.Combats;
using ZombieAttack.Abstracts.Controllers;
using ZombieAttack.Abstracts.Inputs;
using ZombieAttack.Abstracts.Movements;
using ZombieAttack.Animation;
using ZombieAttack.Managers;
using ZombieAttack.Movements;

namespace ZombieAttack.Controllers
{
    public class PlayerController : MonoBehaviour , IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float turnSpeed = 10f;
        [SerializeField] private Transform turnTransform;
        [SerializeField] private Transform spineTransform;

        [Header("UIs")]
        [SerializeField] private GameObject gameOverPanel;
        
        private IInputReader _input;
        private IMover _mover;
        private CharacterAnimation _animation;
        private IHealth _health;
        private IRotator _xRotator;
        private IRotator _yRotator;
        private IRotator _spineRotator;
        private Vector3 _direction;
        private Vector2 _rotation;
        private InventoryController _inventory;

        public Transform TurnTransform => turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorXCharacter(this);
            _yRotator = new RotatorYCharacter(this);
            _spineRotator = new SpineRotator(spineTransform);
            _inventory = GetComponent<InventoryController>();
        }

        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation();
                gameOverPanel.SetActive(true);
            };
            
            EnemyManager.Instance.Targets.Add(this.transform);
        }

        private void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }


        private void Update()
        {
            if(_health.IsDead) return;
            
            _direction = _input.Direction;
            _rotation = _input.Rotation;
            _xRotator.RotationAction(_rotation.x, turnSpeed);
            _yRotator.RotationAction(_rotation.y,turnSpeed);

            if (_input.IsAttackButtonPressed)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }

        private void FixedUpdate()
        {
            if(_health.IsDead) return;
            
            _mover.MoveAction(_direction , moveSpeed);
        }

        private void LateUpdate()
        {
            if(_health.IsDead) return;
            
            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPressed);
            
            _spineRotator.RotationAction(_rotation.y, turnSpeed);
        }
        
    }
}

