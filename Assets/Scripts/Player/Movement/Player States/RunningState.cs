using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IPlayerState
{
    public void EnterState(MovementStateMachine player) { }

    public void UpdateState(MovementStateMachine player)
    {
        Vector2 inputVector = player.GetInputVector();
        if (inputVector == Vector2.zero)
        {
            player.TransitionToState(player.IdleState);
        }
        else
        {
            player.HandleMovement();
        }

        // Check for dodgeroll action
        if (player.canDodgeroll && player.IsDodgerollAction())
        {

            player.TransitionToState(player.DodgerollingState);
        }
        if (player.GetInputVector() ==  Vector2.zero)
        {
            player.movement = Vector2.zero;
            player.TransitionToState(player.IdleState);
        }
    }

    public void ExitState(MovementStateMachine player) { }
}

