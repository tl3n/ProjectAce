using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject punchPoint;
    public float punchRange = 0.5f;

    [SerializeField] PlayerMovement movement;
    public float punchingMovementSpeed = 3f; // Movement speed while punching
    private float currentMovementSpeed; // Current movement speed

    public LayerMask enemyLayers;
    public bool isPunching; // Event to notify punch state change
    public float punchRate = 2f;
    float nextPunchTime = 0f;

    private void Start()
    {
        currentMovementSpeed = movement.movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextPunchTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Punch();
                nextPunchTime = Time.time + 1f / punchRate;
            }
            if (isPunching && Time.time >= nextPunchTime)
            {
                isPunching = false;
                movement.movementSpeed = currentMovementSpeed;
            }
        }
    }

    void Punch()
    {
        animator.SetTrigger("attacking");
        isPunching = true;
        AudioManager.Instance.PlayPlayerSFX(1);
        movement.movementSpeed = punchingMovementSpeed;
       
        // Check the scale of the player
        float playerScaleX = transform.localScale.x;

        // Perform the punch with the flipped punch point position
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.transform.position, punchRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

            // Perform taking damage from our punch
            var healthComponent = enemy.GetComponent<Health>();

            if (healthComponent != null)
            {
                healthComponent.GetHit(1);
            }
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(punchPoint.transform.position, punchRange);
    }
}
