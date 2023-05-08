using UnityEngine;

namespace PlayerControls.PlayerControl.StateManagement
{
    public class AttackState : State
    {
        private float _timePassed;
        private float _clipLength;
        private float _clipSpeed;
        private bool _attack;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Move = Animator.StringToHash("Move");

        public AttackState(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
            Player = player;
            StateMachine = stateMachine;
        }


        public override void Enter()
        {
            base.Enter();
            _attack = false;
            _timePassed = 0f;
            Player.animator.SetTrigger(Attack);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (AttackAction.triggered)
            {
                _attack = true;
            }
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            _timePassed += Time.deltaTime;
            _clipLength = Player.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
            _clipSpeed = Player.animator.GetCurrentAnimatorStateInfo(1).speed;

            if (_timePassed >= _clipLength / _clipSpeed && _attack)
            {
                StateMachine.ChangeState(Player.Attacking);
                Player.animator.SetTrigger(Move);
            }
        
            if (_timePassed >= _clipLength / _clipSpeed)
            {
                StateMachine.ChangeState(Player.Combating);
                Player.animator.SetTrigger(Move);
            }
        }
    }
}
