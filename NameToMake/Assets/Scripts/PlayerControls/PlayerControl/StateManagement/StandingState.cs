using Sound;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl.StateManagement
{
    public class StandingState :State
    {
        float _playerSpeed;
         float _rotateVelocity;
         float _speedDampTime;
         float _rotateSpeedMovement;
         float _attackRange;
         bool _drawWeapon;
         
         private Transform _transform;
         private NavMeshAgent _navMeshAgent;
         private static readonly int DrawWeapon = Animator.StringToHash("DrawWeapon");

         public StandingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
            Player = player;
            StateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            _transform = Player.transform;
            _navMeshAgent = Player.navMeshAgent;
           
            _rotateSpeedMovement = Player.rotationDampTime;
            _drawWeapon = false;

            MoveAction.performed += OnMovePerformed;
           // attackAction.performed += OnEnemyTargetedPerformed;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            float speed = Player.navMeshAgent.velocity.magnitude/Player.navMeshAgent.speed;
            Player.animator.SetFloat(Player.Speed, speed, Player.speedDampTime, Time.deltaTime);
            
            if (_drawWeapon)
            {
                StateMachine.ChangeState(Player.Combating);
                Player.animator.SetTrigger(DrawWeapon);
                SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerDrawSword,0.4f, Player.transform.position);
            }
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (DrawWeaponAction.triggered)
            {
                _drawWeapon = true;
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
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - _transform.position);
                    float rotationY = Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref _rotateVelocity, _rotateSpeedMovement* (Time.deltaTime*5));
        
                //    _transform.eulerAngles = new UnityEngine.Vector3(0, rotationY, 0);
                }
            }
        }
    }
}