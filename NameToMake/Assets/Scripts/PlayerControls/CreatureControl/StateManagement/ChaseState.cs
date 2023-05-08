using PlayerControls.PlayerControl;
using UnityEngine;
using UnityEngine.AI;

namespace PlayerControls.CreatureControl.StateManagement
{
    public class ChaseState : StateMachineBehaviour
    {
        private NavMeshAgent _agent;
        
        private GameObject _player;
        private Player _playerScriptComponent;
    
        private static readonly int IsChasing = Animator.StringToHash("IsChasing");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _agent = animator.GetComponent<NavMeshAgent>();
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScriptComponent = _player.GetComponent<Player>();
            _agent.speed = 3.5f;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_playerScriptComponent.isAlive)
            {
                var position = _player.transform.position;
                _agent.SetDestination(position);
                float distance = Vector3.Distance(position, animator.transform.position);
                if (distance > 13)
                {
                    animator.SetBool(IsChasing,false);
                }
                if (distance < 2.5f)
                {
                    animator.SetBool(IsAttacking,true);
                }
            }
            
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _agent.SetDestination(animator.transform.position);
        }
        
    }
}
