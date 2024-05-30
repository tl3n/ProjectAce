using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    public Rigidbody2D rb;
    //PlayerCombat playerCombat;
    public float force;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        //playerCombat = GetComponent<PlayerCombat>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();  
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy")) || (collision.gameObject.CompareTag("Wall")))
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
