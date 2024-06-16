using UnityEngine;

public class RunningState : IPlayerState
{
    /// <summary>
    /// State Machine field to interact with
    /// </summary>
    private Player player;

    public RunningState(Player player)
    {
        this.player = player;
    }

    public void EnterState() { }

    public void UpdateState()
    {
        if (player.inputVector == Vector2.zero)
        {
            player.playerStateMachine.TransitionToState(player.playerStateMachine.IdleState);
        }
        else
        {
            player.HandleMovement();
        }

        if (player.canDodgeroll && player.IsDodgerollAction())
        {
            player.playerStateMachine.TransitionToState(player.playerStateMachine.DodgerollingState);
        }
    }

    public void ExitState() { }
}
    