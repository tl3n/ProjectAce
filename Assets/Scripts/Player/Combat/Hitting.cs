using UnityEngine;

public class Hitting : Knockback
{
    /// <summary>
    /// Melle weapon of the player
    /// </summary>
    [SerializeField] private MelleWeapon weapon;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        if (gameObject.GetComponentInChildren<Transform>(false).Find("RotatePoint")
                .GetComponentInChildren<Transform>(false).Find("Weapon").gameObject != null) SetActive(true);
        else SetActive(false);
    }
    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        
    }
}
