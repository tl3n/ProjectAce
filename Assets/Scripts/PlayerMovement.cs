using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{



    private bool canDodgeroll = true;
    private bool isDodgerolling;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lastMoveDirection = Vector2.zero;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private float dodgerollPower = 16f;
    [SerializeField] private float dodgerollTime = 0.2f;
    [SerializeField] private float dodgerollCooldown = 2f; //cooldown after which player is able to dash again

    [SerializeField] private float movementSpeed = 7f;

    public enum MovementState {idle, running, dodgerolling } //very questionable public, probably should refactor to private
    MovementState movementState = MovementState.idle;

    [SerializeField] private GameInput gameInput;

    float dirX = 0f;
    float dirY = 0f;


    // Start is called before the first frame update
    private void Start()
    {

        gameInput.OnDodgerollAction += GameInput_OnDodgerollAction;
        //Rigid body initialization of the player sprite
        //for the movement realization convenience
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void GameInput_OnDodgerollAction(object sender, System.EventArgs e)
    {
        if(canDodgeroll) {
            StartCoroutine(Dodgeroll());
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDodgerolling)
        {
            return;
        }

        HandleMovement();

       
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector2 movement = inputVector * movementSpeed;

        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement.normalized; // Save the last movement direction
            if (inputVector.x <0f)
            {
                playerAnimator.sprite.flipX = true;
                movementState = MovementState.running;

            }
            else
            {
                playerAnimator.sprite.flipX = false;
                movementState = MovementState.running;
            }
            
        }
        else
        {
            movementState = MovementState.idle;
        }


        playerRigidbody.velocity = movement;
    }



 
    private IEnumerator Dodgeroll()
    {
        movementState = MovementState.dodgerolling;
        canDodgeroll = false;
        isDodgerolling = true;
        float originalGravity = playerRigidbody.gravityScale;
        playerRigidbody.gravityScale = 0f;

        Vector2 dodgeDirection = new Vector2(dirX, dirY).normalized;

        // If player is not moving, check player's last running direction
        if (dodgeDirection == Vector2.zero && lastMoveDirection != Vector2.zero)
        {
            dodgeDirection = lastMoveDirection;
        }
        else
            dodgeDirection = new Vector2(playerAnimator.sprite.flipX ? -1 : 1, 0);

        playerRigidbody.velocity = dodgeDirection * dodgerollPower;

        yield return new WaitForSeconds(dodgerollTime);
        playerRigidbody.gravityScale = originalGravity;
        isDodgerolling = false;
        yield return new WaitForSeconds(dodgerollCooldown);
        canDodgeroll = true;
        movementState = MovementState.idle;
    }


    public MovementState returnMovementState()
    {
        return movementState;
    }

}