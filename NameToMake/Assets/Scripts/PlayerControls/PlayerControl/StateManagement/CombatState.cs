using Sound;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl.StateManagement
{
    public class CombatState : State
    { 
        float rotationSpeed;
        float rotateSpeedMovement;
        bool sheathWeapon;
        bool attack;
        
        private static readonly int SheathWeapon = Animator.StringToHash("SheathWeapon");
        private static readonly int Attack = Animator.StringToHash("Attack");
        
        private Transform _transform;
        private NavMeshAgent _navMeshAgent;
        public CombatState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
        {
            Player = _player;
            StateMachine = _stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            sheathWeapon = false;
            attack = false;
            
            rotateSpeedMovement = Player.rotationDampTime;
            _transform = Player.transform;
            rotationSpeed = Player.rotationSpeed;
            _navMeshAgent = Player.navMeshAgent;
            
            moveAction.performed += OnMovePerformed;
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (drawWeaponAction.triggered)
            {
                sheathWeapon = true;
            }
            if (attackAction.triggered)
            {
                attack = true;
            }
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            float speed = Player.navMeshAgent.velocity.magnitude/Player.navMeshAgent.speed;
            Player.animator.SetFloat(Player.Speed, speed, Player.speedDampTime, Time.deltaTime);
            if (sheathWeapon)
            {
                Player.animator.SetTrigger(SheathWeapon);
                StateMachine.ChangeState(Player.Standing);
                SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerDrawSword,0.5f,Player.transform.position);
            }
            if (attack)
            {
                Player.animator.SetTrigger(Attack);
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
                    float rotationY = Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotationSpeed, rotateSpeedMovement* (Time.deltaTime*5));
                    _transform.eulerAngles = new UnityEngine.Vector3(0, rotationY, 0);
                }
            }
        }
    }
}