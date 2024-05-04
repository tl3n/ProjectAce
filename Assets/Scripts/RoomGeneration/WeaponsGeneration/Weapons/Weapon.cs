using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    /// <summary>
    /// Name of the weapon
    /// </summary>
    [SerializeField] protected string weaponName;

    public string WeaponName { get; set; }

    /// <summary>
    /// Each weapon has its own particle system
    /// </summary>
    protected ParticleSystem particleSystem;

    /// <summary>
    /// Initialization of the weapon
    /// </summary>
    public abstract void Initialize();
}