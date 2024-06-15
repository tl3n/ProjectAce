using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Input = UnityEngine.Input;

public class MovementStateMachine: MonoBehaviour
{
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
    private Vector2 dodgeDirection = new Vector2(0, 0).normalized;

    /// <summary>
    /// Direction of input
    /// </summary>
    private Vector2 inputVector;

    /// <summary>
    /// Upscaled input vector
    /// </summary>
    public Vector2 movement;

    /// <summary>
    /// Indicates whether the player is facing right
    /// </summary>
    public bool facingRight = true;

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
    private void Awake()
    {
        IdleState = new IdleState();
        RunningState = new RunningState();
        DodgerollingState = new DodgerollingState();
        currentState = IdleState;

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Start is called before the first frame update
    ///
    /// Rigid body initialization of the player sprite
    /// for the movement realization convenience
    /// </summary>
    private void Start()
    {
        GameInput.Instance.OnDodgerollAction += GameInput_OnDodgerollAction;
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
            TransitionToState(DodgerollingState);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        currentState.UpdateState(this);
        ProperFlip();
    }

    /// <summary>
    /// Transition to a new state
    /// </summary>
    /// <param name="newState"></param>
    public void TransitionToState(IPlayerState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
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
    /// Check if the dodgeroll action has been triggered
    /// </summary>
    /// <returns></returns>
    public bool IsDodgerollAction()
    {
        return Input.GetKeyDown(KeyCode.Space); // Example
    }

    /// <summary>
    /// Most basic movement function
    /// </summary>
    public void HandleMovement()
    {
        inputVector = GameInput.Instance.GetMovementVectorNormalized(); // We get a vector from GameInput because
                                                                        // it is formed based on buttons player is pressing (so based on input)
                                                                        // and we separate input from movement logic itself

        movement = inputVector * movementSpeed; // Use current movement speed

        SetVelocity(movement);
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

        // If player is moving, we dodgeroll in that direction
        if (movement != Vector2.zero)  
            dodgeDirection = GetInputVector().normalized; 
        else
        {
            dodgeDirection = new Vector2(animatorFlipX ? -1 : 1, 0).normalized;
            Debug.Log("Player's dodgeroll direction is diagonal");
        }

        playerRigidbody.velocity = dodgeDirection * dodgerollPower;

        yield return new WaitForSeconds(dodgerollTime); // Waiting until we finish dodgerolling
        isDodgerolling = false;
        TransitionToState(IdleState);
        yield return new WaitForSeconds(dodgerollCooldown); // Cooldown for dodgeroll
        canDodgeroll = true;
    }

    /// <summary>
    /// Properly flip the player sprite based on mouse position
    /// </summary>
    private void ProperFlip()
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

    /// <summary>
    /// Check if the player is dodgerolling
    /// </summary>
    /// <returns></returns>
    public bool IsDodgerolling()
    {
        return isDodgerolling;
    }
}
