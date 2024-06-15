using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using Input = UnityEngine.Input;

public interface IPlayerState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}

public class MovementStateMachine
{
    private Player player;
    public IPlayerState IdleState { get; private set; }
    public IPlayerState RunningState { get; private set; }
    public IPlayerState DodgerollingState { get; private set; }

    private IPlayerState currentState;

    public void Initialize(IPlayerState startingState)
    {
        currentState = startingState;
        startingState.EnterState();
    }

    public MovementStateMachine(Player player)
    {
        this.player = player;
        RunningState = new RunningState(player);
        DodgerollingState = new DodgerollingState(player);
        IdleState = new IdleState(player);
    }

    public void Update()
    {
        currentState.UpdateState();
    }

    public void TransitionToState(IPlayerState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
