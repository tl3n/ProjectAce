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

    /// <summary>
    /// Idle state of the player
    /// </summary>
    public IPlayerState IdleState { get; private set; }

    /// <summary>
    /// Running state of the player
    /// </summary>
    public IPlayerState RunningState { get; private set; }

    /// <summary>
    /// Dodgerolling state of the player
    /// </summary>
    public IPlayerState DodgerollingState { get; private set; }

    /// <summary>
    /// Current state of the player
    /// </summary>
    private IPlayerState currentState;

    /// <summary>
    /// Initialize states and set initial state
    /// </summary>
    public void Initialize(IPlayerState startingState)
    {
        currentState = startingState;
        startingState.EnterState();
    }

    /// <summary>
    /// Constructor of a state machine
    /// </summary>
    public MovementStateMachine(Player player)
    {
        this.player = player;
        RunningState = new RunningState(player);
        DodgerollingState = new DodgerollingState(player);
        IdleState = new IdleState(player);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        currentState.UpdateState();
    }

    /// <summary>
    /// Transition to a new state
    /// </summary>
    /// <param name="newState"></param>
    public void TransitionToState(IPlayerState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
