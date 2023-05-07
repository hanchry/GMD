using System.Collections;
using System.Collections.Generic;
using PlayerControls;
using PlayerControls.PlayerControl;
using PlayerControls.PlayerControl.StateManagement;
using Sound;
using UnityEngine;

public class AttackState : State
{
    private float timePassed;
    private float clipLength;
    private float clipSpeed;
    private bool attack;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Move = Animator.StringToHash("Move");

    public AttackState(Player _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
        Player = _player;
        StateMachine = _stateMachine;
    }


    public override void Enter()
    {
        base.Enter();
        attack = false;
        timePassed = 0f;
        Player.animator.SetTrigger(Attack);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (attackAction.triggered)
        {
            attack = true;
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        clipLength = Player.animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = Player.animator.GetCurrentAnimatorStateInfo(1).speed;

        if (timePassed >= clipLength / clipSpeed && attack)
        {
            StateMachine.ChangeState(Player.Attacking);
        }
        
        if (timePassed >= clipLength / clipSpeed)
        {
            StateMachine.ChangeState(Player.Combating);
            Player.animator.SetTrigger(Move);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
    
}
