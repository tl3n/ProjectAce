using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Collisions : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool canDodgeroll = true;
    private bool isDodgerolling;
    [SerializeField] private float dodgerollPower = 16f;
    [SerializeField] private float dodgerollTime = 0.2f;
    [SerializeField] private float dodgerollCooldown = 2f; //cooldown after which player is able to dash again

    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private Rigidbody2D rb;

    float dirX = 0f;
    float dirY = 0f;


    // Start is called before the first frame update
    private void Start()
    {
        //Rigid body initialization of the player sprite
        //for the movement realization convenience
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDodgerolling)
        {
            return;
        }

        HandleMovement();
        animationUpdate();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDodgeroll)
        {
            StartCoroutine(Dodgeroll());
        }
    }

    private void HandleMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(dirX, dirY).normalized * movementSpeed;

        PlayerRigidbody.velocity = movement;
    }

    private void animationUpdate()
    {
        if (dirX > 0f || (dirX > 0f && dirY != 0f))
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f || (dirX < 0f && dirY != 0f))
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else if (dirY != 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private IEnumerator Dodgeroll()
    {
        canDodgeroll = false;
        isDodgerolling = true;
        anim.SetBool("dodgerolling", isDodgerolling); // Start the dodgerolling animation
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Determine the direction of the dash based on the player's facing direction
        float dodgerollDirection = sprite.flipX ? -1f : 1f;

        rb.velocity = new Vector2(dodgerollDirection * dodgerollPower, 0f);
        yield return new WaitForSeconds(dodgerollTime);

        rb.gravityScale = originalGravity;
        isDodgerolling = false;
        anim.SetBool("dodgerolling", isDodgerolling); // Stop the dodgerolling animation
        yield return new WaitForSeconds(dodgerollCooldown);
        canDodgeroll = true;
    }

}
