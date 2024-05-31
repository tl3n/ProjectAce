using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangerWeapon : Weapon
{
    /// <summary>
    /// Position of the mouse
    /// </summary>
    private Vector3 mousePos;

    /// <summary>
    /// Main camera
    /// </summary>
    private Camera mainCam;

    /// <summary>
    /// Rigidbody of the bullet
    /// </summary>
    protected Rigidbody2D rigidBody;

    /// <summary>
    /// Force to calculate velocity of bullet
    /// </summary>
    [SerializeField] protected float force;

    /// <summary>
    /// Damage of the bullet
    /// </summary>
    [SerializeField] protected int damage;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidBody = GetComponent<Rigidbody2D>();  
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    /// <summary>
    /// Check object with which bullet has been collided
    /// </summary>
    /// <param name="collision">Collision of bullet with other object</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy")) || (collision.gameObject.CompareTag("Wall")) || (collision.gameObject.CompareTag("Door")))
        {
            Debug.Log("GET HIT " + collision.gameObject.name);
            // Perform taking damage from the bullet
            var healthComponent = collision.gameObject.GetComponent<Health>();

            if (healthComponent != null)
            {
                healthComponent.GetHit(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}