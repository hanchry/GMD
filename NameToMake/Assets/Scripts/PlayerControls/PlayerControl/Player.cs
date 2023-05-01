using PlayerControls.PlayerControl.StateManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl
{
    public class Player : MonoBehaviour
    {
        [Header("Controls")] 
        public float playerSpeed = 5.0f;
        public float rotationSpeed;

        public static readonly int Speed = Animator.StringToHash("Speed");
        
        [Header("Animation Smoothing")]
        [Range(0, 1)]
        public float speedDampTime = 0.1f;
        [Range(0, 1)]
        public float rotationDampTime = 0.05f;
        [Range(0, 1)]
        public float velocityDampTime = 0.9f;
        
        public StateMachine movementSM;
        public StandingState standing;
        public CombatState combating;
        public AttackState attacking;


       [HideInInspector] 
       public Animator Animator;
       [HideInInspector] 
       public PlayerInput PlayerInput;
       [HideInInspector] 
       public CharacterController CharacterController;
       
       public NavMeshAgent NavMeshAgent;

       private void Start()
       {
           CharacterController = GetComponent<CharacterController>();
            Animator = GetComponent<Animator>();
            PlayerInput = GetComponent<PlayerInput>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            
            movementSM = new StateMachine(); 
            standing = new StandingState(this, movementSM);
            combating = new CombatState(this, movementSM);
            attacking = new AttackState(this, movementSM);
            movementSM.Initialize(standing);
       }

       public void Update()
       { 
           movementSM.currentState.HandleInput(); 
           movementSM.currentState.LogicUpdate();
       }
       public void FixedUpdate()
       {
           movementSM.currentState.PhysicsUpdate();
       }
       
    }
}