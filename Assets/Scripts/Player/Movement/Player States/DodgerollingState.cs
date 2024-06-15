using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgerollingState : IPlayerState
{
    public void EnterState(MovementStateMachine player)
    {
            player.StartCoroutine(player.DodgerollCoroutine());
    }

    public void UpdateState(MovementStateMachine player) { }

    public void ExitState(MovementStateMachine player) { }
}
