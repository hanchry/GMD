using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyStateControllers
{
    public class PatrolState : StateMachineBehaviour
    {   
        private float timer;
        private Transform player;

        private List<Transform> waypoints = new List<Transform>();
    
        private float chaseRange = 8;
    
        private static readonly int IsPatrolling = Animator.StringToHash("IsPatrolling");
        private static readonly int IsChasing = Animator.StringToHash("IsChasing");
    
        private NavMeshAgent agent;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            timer = 0;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        
            // loop through all waypoints and change the destination of the enemy
            agent = animator.GetComponent<NavMeshAgent>();
            agent.speed = 1.5f;
            GameObject gameObject = GameObject.FindGameObjectWithTag("Waypoints");
            foreach (Transform transform in gameObject.transform)
            {
                waypoints.Add(transform);
            }

            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // when reaching the destination give a new destination
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
            }
            // on timer change the patrolling state
            timer += Time.deltaTime;
            if (timer > 10)
            {
                animator.SetBool(IsPatrolling,false);
            }
        
        
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance < chaseRange)
            {
                animator.SetBool(IsChasing,true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // stop the enemy after exiting patrol state
            agent.SetDestination(agent.transform.position);
        }

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
