using System;
using System.Collections;
using Objects;
using PlayerControls.PlayerControl.StateManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace PlayerControls.PlayerControl
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private HealthCanvas _healthCanvas;
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private AtributesSkills _atributesSkills;
        
        [Header("Controls")] 
        public float playerSpeed = 5.0f;
        public float rotationSpeed;
        
        
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
       
       private HealthSystem _healthSystem;

       private static readonly int Die = Animator.StringToHash("Die");
       private static readonly int Damage = Animator.StringToHash("Damage");
       public static readonly int Speed = Animator.StringToHash("Speed");
       
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

            // get from ui
            _healthSystem = new HealthSystem(Convert.ToInt32(_atributesSkills.Hp));
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
               StartCoroutine(DeathPlayer());
           }
           else
           {
               Animator.SetTrigger(Damage);
           }
       }
       
       IEnumerator DeathPlayer()
       {
           yield return new WaitForSeconds(5);
           Destroy(this.gameObject);
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