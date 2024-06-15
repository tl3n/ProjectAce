using UnityEngine;

/// <summary>
/// This class handles player animations based on player movement and state.
/// </summary>
public class PlayerAnimator : MonoBehaviour
{
    /// <summary>
    /// Reference to the MovementStateMachine script to get the current state of the player.
    /// </summary>
    [SerializeField] private MovementStateMachine player;

    /// <summary>
    /// Reference to the Animator component for controlling animations.
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Reference to the SpriteRenderer component for flipping the sprite.
    /// </summary>
    private SpriteRenderer sprite;

    /// <summary>
    /// Enum representing different movement states.
    /// </summary>
    private enum MovementState { idle, running, dodgerolling }

    /// <summary>
    /// Current movement state of the player.
    /// </summary>
    private MovementState movementState = MovementState.idle;

    /// <summary>
    /// Boolean to check if the sprite should be flipped on the X-axis.
    /// </summary>
    private bool animatorFlipX;

    /// <summary>
    /// Vector to store the last movement direction.
    /// </summary>
    private Vector2 lastMoveDir;

    /// <summary>
    /// Initialize references to Animator and SpriteRenderer components.
    /// </summary>
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Update is called once per frame. Handles updating the animation state.
    /// </summary>
    private void Update()
    {
        HandleMovementAnim();
    }

    /// <summary>
    /// Handles updating the animation state based on player movement and state.
    /// </summary>
    private void HandleMovementAnim()
    {
        Vector2 inputVector = player.GetInputVector();

        if (inputVector != Vector2.zero)
        {
            lastMoveDir = inputVector;
            movementState = MovementState.running;

            // Flip the sprite based on movement direction
            if (lastMoveDir.x < 0f) animatorFlipX = !sprite.flipX;
            else if (lastMoveDir.x > 0f) animatorFlipX = sprite.flipX;
        }
        else
        {
            movementState = MovementState.idle;
        }

        if (player.IsDodgerolling())
        {
            movementState = MovementState.dodgerolling;
        }

        // Update the animator with the current movement state
        animator.SetInteger("movementState", (int)movementState);
    }

    /// <summary>
    /// Returns whether the sprite should be flipped on the X-axis.
    /// </summary>
    /// <returns>True if the sprite should be flipped, false otherwise.</returns>
    public bool GetAnimatorFlipX()
    {
        return animatorFlipX;
    }
}
