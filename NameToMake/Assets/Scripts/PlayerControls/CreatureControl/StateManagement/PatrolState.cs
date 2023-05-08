using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PlayerControls.CreatureControl.StateManagement
{
    public class PatrolState : StateMachineBehaviour
    {   
        private float _timer;
        private Transform _player;

        private readonly List<Transform> _waypoints = new List<Transform>();

        private const float ChaseRange = 13;

        private static readonly int IsPatrolling = Animator.StringToHash("IsPatrolling");
        private static readonly int IsChasing = Animator.StringToHash("IsChasing");
    
        private NavMeshAgent _agent;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timer = 0;
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        
            // loop through all waypoints and change the destination of the enemy
            _agent = animator.GetComponent<NavMeshAgent>();
            _agent.speed = 1.5f;
            GameObject gameObject = GameObject.FindGameObjectWithTag("Waypoints");
            foreach (Transform transform in gameObject.transform)
            {
                _waypoints.Add(transform);
            }

            _agent.SetDestination(_waypoints[Random.Range(0, _waypoints.Count)].position);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // when reaching the destination give a new destination
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _agent.SetDestination(_waypoints[Random.Range(0, _waypoints.Count)].position);
            }
            // on timer change the patrolling state
            _timer += Time.deltaTime;
            if (_timer > 10)
            {
                animator.SetBool(IsPatrolling,false);
            }
        
        
            float distance = Vector3.Distance(_player.position, animator.transform.position);
            if (distance < ChaseRange)
            {
                animator.SetBool(IsChasing,true);
               
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // stop the enemy after exiting patrol state
            _agent.SetDestination(_agent.transform.position);
        }
        
    }
}
