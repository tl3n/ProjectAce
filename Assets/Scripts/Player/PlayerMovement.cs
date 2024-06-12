using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.U2D;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
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
    /// 
    /// </summary>
    [SerializeField] private float dodgerollPower = 16f;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float dodgerollTime = 0.2f;
    
    /// <summary>
    /// Cooldown after which player is able to dash again
    /// </summary>
    [SerializeField] private float dodgerollCooldown = 2f; 
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public float movementSpeed = 7f;

    /// <summary>
    /// To check if we can dodgeroll. We can't dodgeroll when we are in process of dodgerolling or when there is a cooldown
    /// </summary>
    private bool canDodgeroll = true; 
    
    /// <summary>
    /// Check if we are dodgerolling now
    /// </summary>
    private bool isDodgerolling; 
    
    /// <summary>
    /// Used to store last movement direction to dodgeroll properly
    /// </summary>
    private Vector2 lastMoveDirection = Vector2.zero; 
    
    /// <summary>
    /// Where we store direction which sprite is facing
    /// </summary>
    private bool animatorFlipX; 
    
    /// <summary>
    /// 
    /// </summary>
    private Vector2 dodgeDirection = new Vector2(0, 0).normalized;
    
    /// <summary>
    /// Direction of input
    /// </summary>
    private Vector2 inputVector; 
    
    /// <summary>
    /// Upscaled input vector
    /// </summary>
    private Vector2 movement; 
    
    /// <summary>
    /// 
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
        GameInput.Instance.OnDodgerollAction += GameInput_OnDodgerollAction;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// When event in GameInput happens we call this logic
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void GameInput_OnDodgerollAction(object sender, System.EventArgs e) 
    {
        if(canDodgeroll) 
        {
            StartCoroutine(Dodgeroll()); // Dodgerolling is called in coroutine
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (isDodgerolling) return; // If we are dodgerolling - we can't do anything else. Hence we break update function.

        ProperFlip();
        HandleMovement();
    }

    /// <summary>
    /// 
    /// </summary>
    private void ProperFlip()
    {
        Camera mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Transform rotatePointTransform = GetComponentInChildren<Transform>(true).Find("RotatePoint");
        
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (((rotZ > 90 || rotZ < -90) && facingRight) || 
            ((rotZ < 90 && rotZ > -90) && !facingRight && (rotatePointTransform.rotation.eulerAngles.y < 180)))
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
    /// Most basic movement function
    /// </summary>
    private void HandleMovement() 
    {
        inputVector = GameInput.Instance.GetMovementVectorNormalized(); // We get a vector from GameInput because
                                                                        // it is formed based on buttons player is pressing (so based on input)
                                                                        // and we separate input from movement logic itself

        movement = inputVector * movementSpeed; // Use current movement speed
        if (movement != Vector2.zero) lastMoveDirection = movement.normalized;

        playerRigidbody.velocity = movement;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Dodgeroll()
    {
        canDodgeroll = false;
        isDodgerolling = true;
        animatorFlipX = playerAnimator.GetAnimatorFlipX();
        dodgeDirection = Vector2.zero;

        // If player is moving, we dodgeroll in that direction
        if (movement != Vector2.zero) dodgeDirection = inputVector.normalized;
        // If not moving, dodgeroll in direction which we are facing
        else dodgeDirection = new Vector2(animatorFlipX ? -1 : 1, 0).normalized; 

        playerRigidbody.velocity = dodgeDirection * dodgerollPower;

        yield return new WaitForSeconds(dodgerollTime); // Waiting until we finish dodgerolling
        isDodgerolling = false;
        yield return new WaitForSeconds(dodgerollCooldown); // Cooldown for dodgeroll
        canDodgeroll = true;
    }

    /// <summary>
    /// /Ued in Animator to change moving state and therefore, animation
    /// </summary>
    /// <returns>Status of the dodgerolling</returns>
    public bool GetDodgerollStatus() 
    {
        return isDodgerolling;
    }
}