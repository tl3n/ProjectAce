using System.Collections;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected float thrust = 5;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] protected float knockTime = 0.4f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public MelleWeapon weapon;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    protected IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }

}
