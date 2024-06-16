using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorAnimator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite; 
    [SerializeField] private Enemy enemy;
    Vector2 inputVector;   //used to receive input vector from PlayerMovement class and use it for animating sprite depending on logic of movement
    public enum MovementState { idle, running, attacking} //states of movement to animate the sprite
    public MovementState movementState = MovementState.idle; //default state

    private bool animatorFlipX; //used to return flipX to PlayerMovement class and is used there. isn't used here in this class

    private Vector2 lastMoveDir; //last movement direction, used to avoid animation bugs

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        HandleMovementAnim();
    }

    private void HandleMovementAnim()
    {
        bool isWalking = enemy.isWalking;
        bool isAttacking = enemy.isAttacking;
        //inputVector = transform.position.normalized; //to which direction we are animating
        
        /*if (inputVector != Vector2.zero) //if we are moving in ANY direction
        {
            lastMoveDir = inputVector; //save last move direction

            if (lastMoveDir.x < 0f) //moving left
            {
                animatorFlipX = !sprite.flipX;
                movementState = MovementState.running; //change state


            }
            else if(lastMoveDir.x > 0f) //moving right
            {
                animatorFlipX = sprite.flipX;
                movementState = MovementState.running; //change state

            }
            else //moving on y axis only
            {
                movementState = MovementState.running; //change state
            }
           
        }*/
        if (isWalking)
        {
            movementState = MovementState.running;
        }
        else if (isAttacking)
        {
            movementState = MovementState.attacking;
        }
        else //not moving
        {
            movementState = MovementState.idle; 
        }

        animator.SetInteger("movementState", (int)movementState); //after all checks - change the state in Input System
    }

    public bool GetAnimatorFlipX() //returning direction of the sprite at given moment - used in dodgeroll logic in PlayerMovement

    {
        return animatorFlipX;
    }
}
