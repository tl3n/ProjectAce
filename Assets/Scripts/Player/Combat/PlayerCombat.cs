using System.Collections;
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
    [SerializeField] Player player;
    
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

    private AudioManager audioManager;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        player = GetComponent<Player>();    
        audioManager = GetComponent<AudioManager>();
        currentMovementSpeed = player.movementSpeed;
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
                audioManager.PlayPlayerSFX(0);
                nextPunchTime = Time.time + 1f / punchRate;
            }
            
            if (isPunching && Time.time >= nextPunchTime)
            {
                isPunching = false;
                player.movementSpeed = currentMovementSpeed;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    IEnumerator PunchCoroutine()
    {
        animator.SetTrigger("attacking");
            
        isPunching = true;
        player.movementSpeed = punchingMovementSpeed;

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
            // Perform taking damage from our punch
            var healthComponent = enemy.GetComponent<Health>();
            int damage = 0;
            
            
            if((GetComponent<Hitting>() != null) && (healthComponent != null))
                if(GetComponent<Hitting>().weapon == null)
                {
                    healthComponent.GetHit(1);
                    damage = 1;
                }
                else
                {
                    healthComponent.GetHit(GetComponent<Hitting>().weapon.damage);
                    damage = GetComponent<Hitting>().weapon.damage;
                }
            else Debug.LogError("There is NOT Knockback component");
            
            Debug.Log("We hit " + enemy.name + " " + damage);
        }

        // Wait for the animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 4);

        // Deactivate the collider
        if (punchPoint.GetComponent<CircleCollider2D>() != null) punchPoint.GetComponent<CircleCollider2D>().enabled = false;
        else Debug.LogError("There is NOT collider of PunchPoint");
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
        if (punchPoint == null) return;

        Gizmos.DrawWireSphere(punchPoint.transform.position, punchRange);
    }
}