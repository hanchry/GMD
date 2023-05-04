using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Vector3 = System.Numerics.Vector3;

namespace PlayerControls.PlayerControl.StateManagement
{
    public class StandingState :State
    {
        float playerSpeed;
         float rotateVelocity;
         float speedDampTime;
         float rotateSpeedMovement;
         float attackRange;
         bool drawWeapon;
         
         private Transform _transform;
         private NavMeshAgent _navMeshAgent;
         private static readonly int DrawWeapon = Animator.StringToHash("DrawWeapon");

         public GameObject targetedEnemy;
         
         public StandingState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
        {
            Player = _player;
            StateMachine = _stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            input = Vector2.zero;
            _transform = Player.transform;
            _navMeshAgent = Player.NavMeshAgent;
           
            rotateSpeedMovement = Player.rotationDampTime;
            drawWeapon = false;

            moveAction.performed += OnMovePerformed;
           // attackAction.performed += OnEnemyTargetedPerformed;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            float speed = Player.NavMeshAgent.velocity.magnitude/Player.NavMeshAgent.speed;
            Player.Animator.SetFloat(Player.Speed, speed, Player.speedDampTime, Time.deltaTime);
            
            if (drawWeapon)
            {
                StateMachine.ChangeState(Player.combating);
                Player.Animator.SetTrigger(DrawWeapon);
            }
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (drawWeaponAction.triggered)
            {
                drawWeapon = true;
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
                    float rotationY = Mathf.SmoothDampAngle(_transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement* (Time.deltaTime*5));
        
                    _transform.eulerAngles = new UnityEngine.Vector3(0, rotationY, 0);
                }
            }
        }
        public void OnEnemyTargetedPerformed(InputAction.CallbackContext context)
        {
            if (targetedEnemy != null)
            {

                UnityEngine.Vector3 position = Player.gameObject.transform.position;   
                UnityEngine.Vector3 myVector = new UnityEngine.Vector3(position.x, position.y, position.z);
                System.Numerics.Vector3 numericVector = new System.Numerics.Vector3(0,0,0);
                // if (Vector3.Distance( myVector , targetedEnemy.transform.position) > attackRange)
                // {
                //     _navMeshAgent.SetDestination(targetedEnemy.transform.position);
                //     _navMeshAgent.stoppingDistance = attackRange;
                // }
            }
        }
    }
}