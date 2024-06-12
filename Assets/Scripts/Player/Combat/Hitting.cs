using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : Knockback
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private MelleWeapon weapon;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (gameObject.GetComponentInChildren<Transform>(false).Find("RotatePoint")
                .GetComponentInChildren<Transform>(false).Find("Weapon").gameObject != null)
        {
            SetActive(true);
        }
        else
        {
            SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
