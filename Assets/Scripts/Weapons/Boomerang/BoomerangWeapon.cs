using UnityEngine;

public abstract class BoomerangWeapon : Weapon
{
    /// <summary>
    /// Force to calculate velocity of bullet
    /// </summary>
    [SerializeField] protected float force;

    /// <summary>
    /// Damage of the bullet
    /// </summary>
    [SerializeField] protected int damage;

    /// <summary>
    /// Maximum distance the boomerang can travel
    /// </summary>
    [SerializeField] protected float maxDistance;

    /// <summary>
    /// Rigidbody of the bullet
    /// </summary>
    protected Rigidbody2D rigidBody;

    /// <summary>
    /// Position of the mouse
    /// </summary>
    private Vector3 mousePos;

    /// <summary>
    /// Main camera
    /// </summary>
    private Camera mainCam;

    /// <summary>
    /// The starting position of the boomerang
    /// </summary>
    private Vector3 startingPosition;

    /// <summary>
    /// Flag to indicate if the boomerang should return
    /// </summary>
    private bool shouldReturn = false;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        base.Start();

        gameObject.tag = "BoomerangWeapon";
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidBody = GetComponent<Rigidbody2D>();

        if (isEquipped)
        {
            startingPosition = transform.position; // Store the starting position
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - transform.position;
            Vector3 rotation = transform.position - mousePos;
            rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        base.Update();

        // Check if the boomerang has traveled beyond the maximum distance
        if ((Vector3.Distance(transform.position, startingPosition) > maxDistance) && (isEquipped))
        {
            shouldReturn = true;
        }

        // If the boomerang should return
        if (shouldReturn)
        {
            // Calculate the direction towards the player's current position
            Vector3 direction = rotatePointGameObject.transform.position - transform.position;
            rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);

            // Check if the boomerang has returned to the player's position
            if (Vector3.Distance(transform.position, rotatePointGameObject.transform.position) < 0.1f)
            {
                Shooting rotatePoint = rotatePointGameObject.GetComponent<Shooting>();
                rotatePoint.canFire = true;
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Fixes collision with other objects
    /// </summary>
    /// <param name="collision">Collision with object</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((isEquipped) && ((collision.gameObject.CompareTag("Enemy"))
             || (collision.gameObject.CompareTag("Wall")) || (collision.gameObject.CompareTag("Door"))))
        {
            Debug.Log("GET HIT " + collision.gameObject.name);
            // Perform taking damage from the bullet
            var healthComponent = collision.gameObject.GetComponent<Health>();
            if (healthComponent != null)
            {
                healthComponent.GetHit(damage);
            }

           shouldReturn = true;
        }
    }
}