using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour //TODO: implement singleton
{

    public event EventHandler OnDodgerollAction;
    private PlayerInputActions playerInputActions;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Dodgeroll.performed += Dodgeroll_performed;
    }

    private void Dodgeroll_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnDodgerollAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {

        Vector2 inputVector =  playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
