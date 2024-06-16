using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{
    /// <summary>
    /// State Machine field to interact with
    /// </summary>
    public MovementStateMachine playerStateMachine;

    /// <summary>
    /// Player physical body (without visuals)
    /// </summary>
    [SerializeField] private Rigidbody2D playerRigidbody;

    /// <summary>
    /// Object of visuals. Needed to get a direction which sprite is facing
    /// </summary>
    [SerializeField] private PlayerAnimator playerAnimator;

    /// <summary>
    /// Power of the dodgeroll
    /// </summary>
    [SerializeField] private float dodgerollPower = 16f;

    /// <summary>
    /// Duration of the dodgeroll
    /// </summary>
    [SerializeField] private float dodgerollTime = 0.2f;

    /// <summary>
    /// Cooldown after which player is able to dash again
    /// </summary>
    [SerializeField] private float dodgerollCooldown = 2f;

    /// <summary>
    /// Movement speed of the player
    /// </summary>
    [SerializeField] public float movementSpeed = 7f;


    /// <summary>
    /// To check if we can dodgeroll. We can't dodgeroll when we are in process of dodgerolling or when there is a cooldown
    /// </summary>
    public bool canDodgeroll = true;

    /// <summary>
    /// Check if we are dodgerolling now
    /// </summary>
    private bool isDodgerolling;

    /// <summary>
    /// Where we store direction which sprite is facing
    /// </summary>
    private bool animatorFlipX;

    /// <summary>
    /// Direction of the dodgeroll
    /// </summary>
    public Vector2 dodgeDirection = new Vector2(0, 0).normalized;

    /// <summary>
    /// Direction of input
    /// </summary>
    public Vector2 inputVector;

    /// <summary>
    /// Upscaled input vector
    /// </summary>
    public Vector2 movement;

    /// <summary>
    /// Indicates whether the player is facing right
    /// </summary>
    public bool facingRight = true;

    /// <summary>
    /// Start is called before the first frame update
    ///
    /// Rigid body initialization of the player sprite
    /// for the movement realization convenience
    /// </summary>
    private void Start()
    {
        playerStateMachine = new MovementStateMachine(this);
        playerStateMachine.Initialize(playerStateMachine.IdleState);
        GameInput.Instance.OnDodgerollAction += GameInput_OnDodgerollAction;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        playerStateMachine.Update();
        ProperFlip();
    }

    /// <summary>
    /// When event in GameInput happens we call this logic
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameInput_OnDodgerollAction(object sender, System.EventArgs e)
    {
        if (canDodgeroll)
        {
            playerStateMachine.TransitionToState(playerStateMachine.DodgerollingState);
        }
    }

    /// <summary>
    /// Coroutine for handling the dodgeroll action
    /// </summary>
    /// <returns></returns>
    /// 
    public IEnumerator DodgerollCoroutine()
    {
        canDodgeroll = false;
        isDodgerolling = true;

        animatorFlipX = playerAnimator.GetAnimatorFlipX();
        dodgeDirection = Vector2.zero;

        if (inputVector != Vector2.zero)
            dodgeDirection = GetInputVector().normalized;
        else
        {
            dodgeDirection = new Vector2(animatorFlipX ? -1 : 1, 0).normalized;
        }

        playerRigidbody.velocity = dodgeDirection * dodgerollPower;

        yield return new WaitForSeconds(dodgerollTime);
        isDodgerolling = false;
        playerStateMachine.TransitionToState(playerStateMachine.IdleState);
        yield return new WaitForSeconds(dodgerollCooldown);
        canDodgeroll = true;
    }

    /// <summary>
    /// Check if the player is dodgerolling
    /// </summary>
    /// <returns></returns>
    public bool IsDodgerolling()
    {
        return isDodgerolling;
    }

    /// <summary>
    /// Check if the dodgeroll action has been triggered
    /// </summary>
    /// <returns></returns>
    public bool IsDodgerollAction()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    /// <summary>
    /// Get the input vector from the GameInput instance
    /// </summary>
    /// <returns></returns>
    public Vector2 GetInputVector()
    {
        return GameInput.Instance.GetMovementVectorNormalized();
    }

    /// <summary>
    /// Set the velocity of the player's Rigidbody2D
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector2 velocity)
    {
        playerRigidbody.velocity = velocity;
    }

    /// <summary>
    /// Most basic movement function
    /// </summary>
    public void HandleMovement()
    {
        inputVector = GetInputVector();
        if (inputVector != Vector2.zero)
        {
            movement = inputVector * movementSpeed;
            SetVelocity(movement);
        }
        else
        {
            SetVelocity(Vector2.zero);
        }
    }

    /// <summary>
    /// Properly flip the player sprite based on mouse position
    /// </summary>
    public void ProperFlip()
    {
        Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Transform rotatePointTransform = GetComponentInChildren<Transform>(true).Find("RotatePoint");

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (((rotZ > 90 || rotZ < -90) && facingRight) || ((rotZ < 90 && rotZ > -90) && !facingRight && (rotatePointTransform.rotation.eulerAngles.y < 180)))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));

            if (rotatePointTransform != null)
            {
                rotatePointTransform.rotation = Quaternion.Euler(rotatePointTransform.rotation.eulerAngles.x, 0f, rotatePointTransform.rotation.eulerAngles.z);
            }
        }
    }
}
