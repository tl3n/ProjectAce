using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Camera mainCam;
    
    /// <summary>
    /// 
    /// </summary>
    private Vector3 mousePos;
    
    /// <summary>
    /// 
    /// </summary>
    public Weapon bullet;
    
    /// <summary>
    /// 
    /// </summary>
    public Transform bulletTransform;
    
    /// <summary>
    /// 
    /// </summary>
    public bool canFire;
    
    /// <summary>
    /// 
    /// </summary>
    private float timer;
    
    /// <summary>
    /// 
    /// </summary>
    public float timeBetweenFiring;

    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //SetBullet(bullet);
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
