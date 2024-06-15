using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    public void EnterState(MovementStateMachine player)
    {
        player.SetVelocity(Vector2.zero); // Stop movement
    }

    public void UpdateState(MovementStateMachine player)
    {
        if (player.GetInputVector() != Vector2.zero)
        {
            player.TransitionToState(player.RunningState);
        }
    }

    public void ExitState(MovementStateMachine player) { }
}

