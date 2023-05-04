using PlayerControls.PlayerControl.StateManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace PlayerControls.PlayerControl
{
    public class Player : MonoBehaviour
    {
        
        private HealthSystem _healthSystem;
        [SerializeField]
        private HealthCanvas _healthCanvas;
        [SerializeField]
        private Slider _slider;
        
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
       
       
       public NavMeshAgent NavMeshAgent;

       private static readonly int Die = Animator.StringToHash("Die");
       private static readonly int Damage = Animator.StringToHash("Damage");
       private void Start()
       {
           
            Animator = GetComponent<Animator>();
            PlayerInput = GetComponent<PlayerInput>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            
            movementSM = new StateMachine(); 
            standing = new StandingState(this, movementSM);
            combating = new CombatState(this, movementSM);
            attacking = new AttackState(this, movementSM);
            movementSM.Initialize(standing);
            
            _healthSystem = new HealthSystem(100);
            _healthCanvas.Setup(_healthSystem,_slider);
            _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
       }

       public void TakeDamage(int damage)
       {
           this._healthSystem.Damage(damage);
       }
       
       private  void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
       {
           float healthValue = _healthSystem.GetHealthPercent();
             
           if (healthValue <= 0)
           {
               Animator.SetTrigger(Die);
               GetComponent<Collider>().enabled = false;
               // add wait for 5 sec
               //  Destroy(this.gameObject);
           }
           else
           {
               Animator.SetTrigger(Damage);
           }
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