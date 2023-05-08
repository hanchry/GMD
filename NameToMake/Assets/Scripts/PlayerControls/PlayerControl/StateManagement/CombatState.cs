using Sound;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl.StateManagement
{
    public class CombatState : State
    { 
        float _rotationSpeed;
        float _rotateSpeedMovement;
        bool _sheathWeapon;
        bool _attack;
        
        private static readonly int SheathWeapon = Animator.StringToHash("SheathWeapon");
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        private Transform _transform;
        private NavMeshAgent _navMeshAgent;
        public CombatState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
            Player = player;
            StateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            _sheathWeapon = false;
            _attack = false;
            
            _rotateSpeedMovement = Player.rotationDampTime;
            _transform = Player.transform;
            _rotationSpeed = Player.rotationSpeed;
            _navMeshAgent = Player.navMeshAgent;
            
            MoveAction.performed += OnMovePerformed;
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (DrawWeaponAction.triggered)
            {
                _sheathWeapon = true;
            }
            if (AttackAction.triggered)
            {
                _attack = true;
            }
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            float speed = Player.navMeshAgent.velocity.magnitude/Player.navMeshAgent.speed;
            Player.animator.SetFloat(Player.Speed, speed, Player.speedDampTime, Time.deltaTime);
            if (_sheathWeapon)
            {
                Player.animator.SetTrigger(SheathWeapon);
                StateMachine.ChangeState(Player.Standing);
                SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerDrawSword,0.5f,Player.transform.position);
            }
            if (_attack)
            {
                Player.animator.SetTrigger(Attack);
              //  RotatePlayer();
                StateMachine.ChangeState(Player.Attacking);
                SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerSwordSlash,0.5f,Player.transform.position);
                
            }
        }
        public void OnMovePerformed(InputAction.CallbackContext context)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    _navMeshAgent.SetDestination(hit.point);
                    _navMeshAgent.stoppingDistance = 0;
                    UnityEngine.Quaternion rotationToLookAt = UnityEngine.Quaternion.LookRotation(hit.point - _transform.position);
                    float rotationY = Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref _rotationSpeed, _rotateSpeedMovement* (Time.deltaTime*5));
                    _transform.eulerAngles = new UnityEngine.Vector3(0, rotationY, 0);
                }
            }
        }
        public void TargetEnemyAndAttack()
        {
           
        }
    }
}