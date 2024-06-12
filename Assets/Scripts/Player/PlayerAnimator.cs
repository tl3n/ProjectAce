using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    /// <summary>
    /// PlayerMovement component of the player
    /// </summary>
    [SerializeField] private PlayerMovement player;
    
    /// <summary>
    /// Animator component of the player
    /// </summary>
    private Animator animator;
    
    /// <summary>
    /// SpriteRenderer component of the player
    /// </summary>
    private SpriteRenderer sprite; 
    
    /// <summary>
    /// States of movement to animate the sprite
    /// </summary>
    private enum MovementState { idle, running, dodgerolling } 
    
    /// <summary>
    /// Default state
    /// </summary>
    private MovementState movementState = MovementState.idle; 

    /// <summary>
    /// Used to return flipX to PlayerMovement class and is used there. isn't used here in this class
    /// </summary>
    private bool animatorFlipX; 

    /// <summary>
    /// Last movement direction, used to avoid animation bugs
    /// </summary>
    private Vector2 lastMoveDir; 

    
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        HandleMovementAnim();
    }

    /// <summary>
    /// 
    /// </summary>
    private void HandleMovementAnim()
    {
        Vector2 inputVector;
        inputVector = GameInput.Instance.GetMovementVectorNormalized(); // To which direction we are animating
        
        if (inputVector != Vector2.zero) // If we are moving in ANY direction
        {
            lastMoveDir = inputVector; // Save last move direction
            movementState = MovementState.running; // Change state to running

            if (lastMoveDir.x < 0f) animatorFlipX = !sprite.flipX; // Moving left
            else if(lastMoveDir.x > 0f) animatorFlipX = sprite.flipX; // Moving right
        }
        else movementState = MovementState.idle; // Not moving

        if (player.GetDodgerollStatus()) movementState = MovementState.dodgerolling; // If dodgeroling = change state to appropriate

        animator.SetInteger("movementState", (int)movementState); // After all checks - change the state in Input System
    }

    /// <summary>
    /// Returning direction of the sprite at given moment - used in dodgeroll logic in PlayerMovement
    /// </summary>
    /// <returns>Direction of the sprite</returns>
    public bool GetAnimatorFlipX() 
    {
        return animatorFlipX;
    }
}


