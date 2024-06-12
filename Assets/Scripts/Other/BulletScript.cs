using UnityEngine;

public class BulletScript : MonoBehaviour
{
    /// <summary>
    /// Position of the mouse
    /// </summary>
    private Vector3 mousePos;
    
    /// <summary>
    /// Main camera of the scene
    /// </summary>
    private Camera mainCam;
    
    /// <summary>
    /// 
    /// </summary>
    public Rigidbody2D rb;
    
    /// <summary>
    /// Force of the bullet
    /// </summary>
    public float force;
    
    /// <summary>
    /// Damage of the bullet
    /// </summary>
    public int damage = 1;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();  
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GET HIT " + collision.gameObject.name);
            // Perform taking damage from the bullet
            var healthComponent = collision.gameObject.GetComponent<Health>();

            if (healthComponent != null) healthComponent.GetHit(damage);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
