using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControls.PlayerControl.StateManagement
{

    public class State
    {
        public Player Player;
        public StateMachine StateMachine;
        protected Vector2 input;

        public InputAction moveAction;
        public InputAction drawWeaponAction;
        public InputAction attackAction;

        public State(Player _player, StateMachine _stateMachine)
        {
            Player = _player;
            StateMachine = _stateMachine;

            moveAction = _player.playerInput.actions["Move"];
            drawWeaponAction= _player.playerInput.actions["DrawWeapon"];
            attackAction = _player.playerInput.actions["Attack"];
        }

        public virtual void Enter()
        {
            Debug.Log("enter state: " + this.ToString());
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