using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public GameObject attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool isAttacking; // Event to notify attack state change
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        
        animator.SetTrigger("attacking");
        isAttacking = true;


        // Check the scale of the player
        float playerScaleX = transform.localScale.x;

        // If the player is facing left, flip the attack point position
        Vector3 flippedAttackPointPosition = attackPoint.transform.position;
        if (playerScaleX < 0)
        {
            flippedAttackPointPosition.x *= -1f;
        }

        // Perform the attack with the flipped attack point position
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(flippedAttackPointPosition, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            
            Debug.Log("We hit " + enemy.name);
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
