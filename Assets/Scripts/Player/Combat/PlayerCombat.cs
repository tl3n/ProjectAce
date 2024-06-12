using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public Animator animator;
    
    /// <summary>
    /// 
    /// </summary>
    public GameObject punchPoint;
    
    /// <summary>
    /// 
    /// </summary>
    public float punchRange = 0.5f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] PlayerMovement movement;
    
    /// <summary>
    /// Movement speed while punching
    /// </summary>
    public float punchingMovementSpeed = 3f; 
    
    /// <summary>
    /// Current movement speed
    /// </summary>
    private float currentMovementSpeed; 

    /// <summary>
    /// 
    /// </summary>
    public LayerMask enemyLayers;
    
    /// <summary>
    /// Event to notify punch state change
    /// </summary>
    public bool isPunching; 
    
    /// <summary>
    /// 
    /// </summary>
    public float punchRate = 2f;
    
    /// <summary>
    /// 
    /// </summary>
    float nextPunchTime = 0f;

    [SerializeField] private IMelleAttack melleAttack;

    
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        currentMovementSpeed = movement.movementSpeed;

        if (gameObject.GetComponent<Knockback>() != null)
        {
            melleAttack = gameObject.GetComponent<Knockback>();
            //melleAttack.SetActive(false);
        }
        else
        {
            Debug.LogError("MelleAttack scripts are NOT existed");
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
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
                
                                
                // if (punchPoint.GetComponent<CircleCollider2D>() != null) punchPoint.GetComponent<CircleCollider2D>().enabled = false;
                // else Debug.LogError("There is NOT collider of PunchPoint");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    IEnumerator PunchCoroutine()
    {
        if (melleAttack != null)
            if (gameObject.GetComponent<Knockback>().enabled)
            {
                animator.SetTrigger("attacking");
            
                isPunching = true;
                movement.movementSpeed = punchingMovementSpeed;

                // Activate the collider
                if (punchPoint.GetComponent<CircleCollider2D>() != null) punchPoint.GetComponent<CircleCollider2D>().enabled = true;
                else Debug.LogError("There is NOT collider of PunchPoint");

                // Check the scale of the player
                float playerScaleX = transform.localScale.x;

                // Perform the punch with the flipped punch point position
                Collider2D[] hitEnemies =
                    Physics2D.OverlapCircleAll(punchPoint.transform.position, punchRange, enemyLayers);

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

                // Wait for the animation to finish
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 4);

                // Deactivate the collider
                if (punchPoint.GetComponent<CircleCollider2D>() != null) punchPoint.GetComponent<CircleCollider2D>().enabled = false;
                else Debug.LogError("There is NOT collider of PunchPoint");
            }
    }

    void Punch()
    {
        StartCoroutine(PunchCoroutine());
    }

    
    /// <summary>
    /// 
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(punchPoint.transform.position, punchRange);
    }
}