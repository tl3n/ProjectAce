using System.Collections;
using System.Collections.Generic;
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

    public float X;
    public float Y;

    Vector2 inputVector;
    
    Vector2 lastMoveDir = new Vector2(0, 0);
    
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

        X = rotation.x;
        Y = rotation.y;
        
        inputVector = GameInput.Instance.GetMovementVectorNormalized(); //to which direction we are animating
        
        if(inputVector.x != 0f) lastMoveDir = inputVector; //save last move direction

        if (lastMoveDir.x < 0f) //moving left
        {
            /*animatorFlipX = !sprite.flipX;
            movementState = MovementState.running; //change state*/
                
            // Обмежуємо поворот в межах правої половини кола (0-180 градусів)
            /*if (rotZ > 170f)
            {
                rotZ = 170f;
            }

            if (rotZ < 250f)
            {
                rotZ = 250f;
            }*/
        }
        else if(lastMoveDir.x > 0f) //moving right
        {
            /*animatorFlipX = sprite.flipX;
            movementState = MovementState.running; //change state*/

            // Обмежуємо поворот в межах правої половини кола (0-180 градусів)
            /*if (rotZ > 50f)
            {
                rotZ = 50f;
            }
        
            if (rotZ < -30f)
            {
                rotZ = -30f;
            }*/
        }
        else //moving on y axis only
        {
            // movementState = MovementState.running; //change state
        }

        

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