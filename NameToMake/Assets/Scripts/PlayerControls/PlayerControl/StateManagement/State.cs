using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl.StateManagement
{

    public class State
    {
        public Player Player;
        public StateMachine StateMachine;

        public readonly InputAction MoveAction;
        public readonly InputAction DrawWeaponAction;
        public readonly InputAction AttackAction;

        public State(Player player, StateMachine stateMachine)
        {
            Player = player;
            StateMachine = stateMachine;

            MoveAction = player.playerInput.actions["Move"];
            DrawWeaponAction= player.playerInput.actions["DrawWeapon"];
            AttackAction = player.playerInput.actions["Attack"];
        }

        public virtual void Enter()
        {
            // Debug.Log("enter state: " + this.ToString());
        }
        
        public virtual void HandleInput()
        {
          
        }
        public virtual void LogicUpdate()
        {
          
        }
        public virtual void PhysicsUpdate()
        {
          
        }
        public virtual void Exit()
        {
          
        }
        
    }
}