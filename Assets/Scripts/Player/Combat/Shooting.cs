using UnityEngine;

public class Shooting : MonoBehaviour
{
    /// <summary>
    /// Main camera
    /// </summary>
    private Camera mainCam;
    
    /// <summary>
    /// Position of the mouse
    /// </summary>
    private Vector3 mousePos;
    
    /// <summary>
    /// Weapon that will be shooting
    /// </summary>
    public Weapon bullet;
    
    /// <summary>
    /// Transform of the weapon
    /// </summary>
    public Transform bulletTransform;
    
    /// <summary>
    /// Opportunity to shoot
    /// </summary>
    public bool canFire;
    
    /// <summary>
    /// Timer to control shooting
    /// </summary>
    private float timer;
    
    /// <summary>
    /// Time between firing
    /// </summary>
    public float timeBetweenFiring;
    
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (bullet != null)
        {  
            if (!canFire)
            {
                if (bullet.CompareTag("RangerWeapon"))
                {
                    timer += Time.deltaTime;
                    if (timer > timeBetweenFiring)
                    {
                        canFire = true;
                        timer = 0;
                    }
                }
            }

            if (Input.GetMouseButtonDown(1) && canFire)
            {
                canFire = false;
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            }
        }
    }
}