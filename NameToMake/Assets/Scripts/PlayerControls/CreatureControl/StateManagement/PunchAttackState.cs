using PlayerControls.PlayerControl;
using UnityEngine;

namespace PlayerControls.CreatureControl.StateManagement
{
    public class PunchAttackState : StateMachineBehaviour
    {

        private GameObject _player;
        private Player _playerScriptComponent;
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScriptComponent = _player.GetComponent<Player>();
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_playerScriptComponent.isAlive)
            {
                Transform transform;
                (transform = animator.transform).LookAt(_player.transform);
                float distance = Vector3.Distance(_player.transform.position, transform.position);
                if (distance > 2.5f)
                {
                    animator.SetBool(IsAttacking,false);
                }
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        
        }
        
    }
}
