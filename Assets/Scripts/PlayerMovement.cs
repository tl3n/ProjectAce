using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{



    private bool canDodgeroll = true; //to check if we can dodgeroll. we can't dodgeroll when we are in process of dodgerolling or when there is a cooldown
    private bool isDodgerolling; //check if we are dodgerolling now
    private Vector2 lastMoveDirection = Vector2.zero; //used to store last movement direction to dodgeroll properly
    [SerializeField] private Rigidbody2D playerRigidbody; //player physical body (without visuals)
    [SerializeField] private PlayerAnimator playerAnimator; //object of visuals. needed to get a direction which sprite is facing
    [SerializeField] private float dodgerollPower = 16f;
    [SerializeField] private float dodgerollTime = 0.2f;
    [SerializeField] private float dodgerollCooldown = 2f; //cooldown after which player is able to dash again

    [SerializeField] private float movementSpeed = 7f;
    private bool animatorFlipX; //where we store direction which sprite is facing
    private Vector2 dodgeDirection = new Vector2(0, 0).normalized;
    private Vector2 inputVector; //direction of input
    private Vector2 movement; //upscaled input vector

   


    // Start is called before the first frame update
    private void Start()
    {

        GameInput.Instance.OnDodgerollAction += GameInput_OnDodgerollAction;
        //Rigid body initialization of the player sprite
        //for the movement realization convenience
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void GameInput_OnDodgerollAction(object sender, System.EventArgs e) //when event in GameInput happens we call this logic
    {
        if(canDodgeroll) {
            StartCoroutine(Dodgeroll()); //dodgerolling is called in coroutine
        }
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isDodgerolling) //if we are dodgerolling - we can't do anything else. hence we break update function.
        {
            return;
        }

        HandleMovement();

       
    }

    private void HandleMovement() //most basic movement function
    {
        inputVector = GameInput.Instance.GetMovementVectorNormalized(); //we get a vector from GameInput because
                                                                        //it is formed based on buttons player is pressing (so based on input)
                                                                        //and we separate input from movement logic itself

         movement = inputVector * movementSpeed;
        if (movement != Vector2.zero)
        {
            lastMoveDirection = movement.normalized;
        }
           



        playerRigidbody.velocity = movement;
    }

  


 
    private IEnumerator Dodgeroll()
    {

        canDodgeroll = false;
        isDodgerolling = true;
        animatorFlipX = playerAnimator.GetAnimatorFlipX();
        

        dodgeDirection = Vector2.zero;

        // If player is moving, we dodgeroll in that direction
        if (movement != Vector2.zero)
        {
            dodgeDirection = inputVector.normalized;
        }
        else { //if not moving, dodgeroll in direction which we are facing
            dodgeDirection = new Vector2(animatorFlipX ? -1 : 1, 0).normalized;
        }

        playerRigidbody.velocity = dodgeDirection * dodgerollPower;

        yield return new WaitForSeconds(dodgerollTime); //waiting until we finish dodgerolling
        isDodgerolling = false;
        yield return new WaitForSeconds(dodgerollCooldown); //cooldown for dodgeroll
        canDodgeroll = true;
        

    }



    public bool GetDodgerollStatus() //used in Animator to change moving state and therefore, animation
    {
        return isDodgerolling;
    }

}