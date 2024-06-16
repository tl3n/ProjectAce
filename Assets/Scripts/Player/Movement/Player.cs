using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;

public class Player : MonoBehaviour
{
    public MovementStateMachine playerStateMachine;

    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private float dodgerollPower = 16f;
    [SerializeField] private float dodgerollTime = 0.2f;
    [SerializeField] private float dodgerollCooldown = 2f;
    [SerializeField] public float movementSpeed = 7f;

    public bool canDodgeroll = true;
    private bool isDodgerolling;
    private bool animatorFlipX;
    public Vector2 dodgeDirection = new Vector2(0, 0).normalized;
    public Vector2 inputVector;
    public Vector2 movement;
    public bool facingRight = true;

    private void Start()
    {
        playerStateMachine = new MovementStateMachine(this);
        playerStateMachine.Initialize(playerStateMachine.IdleState);
        GameInput.Instance.OnDodgerollAction += GameInput_OnDodgerollAction;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerStateMachine.Update();
        ProperFlip();
    }

    private void GameInput_OnDodgerollAction(object sender, System.EventArgs e)
    {
        if (canDodgeroll)
        {
            playerStateMachine.TransitionToState(playerStateMachine.DodgerollingState);
        }
    }

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

    public bool IsDodgerolling()
    {
        return isDodgerolling;
    }

    public bool IsDodgerollAction()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public Vector2 GetInputVector()
    {
        return GameInput.Instance.GetMovementVectorNormalized();
    }

    public void SetVelocity(Vector2 velocity)
    {
        playerRigidbody.velocity = velocity;
    }

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
