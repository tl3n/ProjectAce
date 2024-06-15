using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public interface IEnemyState
{
    /// <summary>
    /// Runs when we first enter the state
    /// </summary>
    public void Enter();

    /// <summary>
    /// Per-frame logic, include condition to transition to a new state
    /// </summary>
    public void Update();

    /// <summary>
    /// Runs when we exit the state
    /// </summary>
    public void Exit();
}

[Serializable]
public class EnemyStateMachine
{
    /// <summary>
    /// Initialization of states for enemy
    /// </summary>
    /// <param name="enemy">Current enemy</param>
    public EnemyStateMachine(Enemy enemy)
    {
        this.passiveState = new PassiveState(enemy);
        this.activeState = new ActiveState(enemy);

        //Initialize(passiveState);
    }

    /// <summary>
    /// Current state of the enemy
    /// </summary>
    public IEnemyState CurrentState { get; private set; }

    /// <summary>
    /// Passive state of the enemy
    /// </summary>
    public PassiveState passiveState;

    /// <summary>
    /// Active state of the enemy
    /// </summary>
    public ActiveState activeState;

    /// <summary>
    /// Initialization of the starting state
    /// </summary>
    /// <param name="startingState">State which will be starting</param>
    public void Initialize(IEnemyState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    /// <summary>
    /// Transition to another state
    /// </summary>
    /// <param name="nextState">State to which will be transition</param>
    public void TransitionTo(IEnemyState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    /// <summary>
    /// Update of the enemy in current state
    /// </summary>
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}

public class ActiveState : IEnemyState
{
    /// <summary>
    /// Current enemy
    /// </summary>
    private Enemy enemy;

    /// <summary>
    /// Initialization of enemy
    /// </summary>
    /// <param name="enemy">Current enemy</param>
    public ActiveState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    /// <summary>
    /// Sets enemy into active 
    /// </summary>
    public void Enter()
    {
        // code that runs when we first enter the state
        enemy.SetActive(true);
    }

    /// <summary>
    /// If enemy is doctor => call method Move()
    /// </summary>
    public void Update()
    {
        // Here we add logic to detect if the conditions exist to 
        // transition to another state �

        Doctor doctor = enemy as Doctor;

        if (doctor.GetType().GetMethod("Move") != null) doctor.Move();
    }

    /// <summary>
    /// something
    /// </summary>
    public void Exit()
    {
        // code that runs when we exit the state
    }
}

public class PassiveState : IEnemyState
{
    /// <summary>
    /// Current enemy
    /// </summary>
    private Enemy enemy;

    /// <summary>
    /// Initialization of enemy
    /// </summary>
    /// <param name="enemy">Current enemy</param>
    public PassiveState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    /// <summary>
    /// Sets enemy into passive 
    /// </summary>
    public void Enter()
    {
        // code that runs when we first enter the state
        enemy.SetActive(false);
    }

    /// <summary>
    /// something
    /// </summary>
    public void Update()
    {
        // Here we add logic to detect if the conditions exist to 
        // transition to another state �
    }

    /// <summary>
    /// something
    /// </summary>
    public void Exit()
    {
        // code that runs when we exit the state
    }
}