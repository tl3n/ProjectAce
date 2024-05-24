using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour 
{
    public static GameInput Instance { get; private set; } //we have single game input system - so use singleton pattern

    public event EventHandler OnDodgerollAction; //for events
    private PlayerInputActions playerInputActions; //used in Input System, object of a class in autogenerated script


    private void Awake()
    {
        if (Instance != null) //check if instance already exists (shouldn't happen)
        {
            Debug.Log("Instance of GameInput already exists.");
        }
        Instance = this; //set singleton instance
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Dodgeroll.performed += Dodgeroll_performed; //subscribe PlayerMovement to the event
    }

    private void Dodgeroll_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) //create event
    {
        OnDodgerollAction?.Invoke(this, EventArgs.Empty); //invoke logic when event happens (dodgeroll in our case)
    }

    public Vector2 GetMovementVectorNormalized() //we get this vector to use it in PlayerMovement to move
    {

        Vector2 inputVector =  playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}