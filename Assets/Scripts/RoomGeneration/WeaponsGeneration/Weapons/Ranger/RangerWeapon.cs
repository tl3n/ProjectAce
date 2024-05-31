using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangerWeapon : Weapon
{
    private Vector3 mousePos;
    private Camera mainCam;
    [SerializeField] protected Rigidbody2D rigidBody;
    [SerializeField] protected float force;
    [SerializeField] protected int damage;    

    // Start is called before the first frame update
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