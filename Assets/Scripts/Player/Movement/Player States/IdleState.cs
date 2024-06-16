using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    private Player player;

    public IdleState(Player player)
    {
        this.player = player;
    }

    public void EnterState()
    {
        player.SetVelocity(Vector2.zero); // Stop movement
    }

    public void UpdateState()
    {
        if (player.GetInputVector() != Vector2.zero)
        {
            player.inputVector = player.GetInputVector();
            player.playerStateMachine.TransitionToState(player.playerStateMachine.RunningState);
        }
    }

    public void ExitState() { }
}


