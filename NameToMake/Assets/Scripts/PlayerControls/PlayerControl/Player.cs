using System;
using System.Collections;
using Objects;
using PlayerControls.PlayerControl.StateManagement;
using Sound;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PlayerControls.PlayerControl
{
    public class Player : MonoBehaviour
    {
        [FormerlySerializedAs("_healthCanvas")] [SerializeField]
        private HealthCanvas healthCanvas;
        [FormerlySerializedAs("_slider")] [SerializeField]
        private Slider slider;
        [FormerlySerializedAs("_atributesSkills")] [SerializeField]
        private AtributesSkills attributesSkills;
        
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
        
        public StateMachine MovementSm;
        public StandingState Standing;
        public CombatState Combating;
        public AttackState Attacking;


       [FormerlySerializedAs("Animator")] [HideInInspector] 
       public Animator animator;
       [FormerlySerializedAs("PlayerInput")] [HideInInspector] 
       public PlayerInput playerInput;
       
       
       [FormerlySerializedAs("NavMeshAgent")] public NavMeshAgent navMeshAgent;
       
       private HealthSystem _healthSystem;
       public bool isAlive;

       private static readonly int Die = Animator.StringToHash("Die");
       private static readonly int Damage = Animator.StringToHash("Damage");
       public static readonly int Speed = Animator.StringToHash("Speed");
       
       
       private void Start()
       {
           
            animator = GetComponent<Animator>();
            playerInput = GetComponent<PlayerInput>();
            navMeshAgent = GetComponent<NavMeshAgent>();

            MovementSm = new StateMachine(); 
            Standing = new StandingState(this, MovementSm);
            Combating = new CombatState(this, MovementSm);
            Attacking = new AttackState(this, MovementSm);
            MovementSm.Initialize(Standing);
            
            _healthSystem = new HealthSystem(Convert.ToInt32(attributesSkills.Hp));
            healthCanvas.Setup(_healthSystem,slider);
            _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
            isAlive = true;

       }

       private static Player Instance { get; set; }
       private void Awake()
       {
           if (Instance == null)
           {
               Instance = this;
               DontDestroyOnLoad(gameObject);
           }
           else
           {
               Destroy(gameObject);
           }
       }

       public void TakeDamage(Damage damage)
       {
           _healthSystem.Damage(damage.Value);
       }
       
       private  void HealthSystem_OnHealthChanged(object sender, EventArgs e)
       {
           float healthValue = _healthSystem.GetHealthPercent();
             
           if (healthValue <= 0)
           {
               animator.SetTrigger(Die);
               
               GetComponent<Collider>().enabled = false;
               isAlive = false;
               SoundManager.PlayCharacterSound(SoundManager.CharacterSound.PlayerDying, transform.position);
               StartCoroutine(DeathPlayer());
           }
           else
           {
               animator.SetTrigger(Damage);
           }
       }
       
       IEnumerator DeathPlayer()
       {
           yield return new WaitForSeconds(5);
           Destroy(this.gameObject);
       }

       private void OnDestroy()
       {
           // If the object is destroyed, respawn it
           // if (spawnedObject != null)
           // {
           //     SpawnObject();
           // }
       }
       private void SpawnPlayer()
       {
           // Create a new instance of the object at the specified position and rotation
          // spawnedObject = Instantiate(gameObject, respawnPosition, respawnRotation);
       }

       public void Update()
       { 
           MovementSm.CurrentState.HandleInput(); 
           MovementSm.CurrentState.LogicUpdate();
       }
       public void FixedUpdate()
       {
           MovementSm.CurrentState.PhysicsUpdate();
       }
       
    }
}