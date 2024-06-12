using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour, IMelleAttack
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
    /// State to choose melee attack strategy
    /// </summary>
    /// <param name="state">Enabled or not</param>
    public void SetActive(bool state)
    {
        enabled = state;
    }
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        if (gameObject.GetComponentInChildren<Transform>(false).Find("RotatePoint")
                .GetComponentInChildren<Transform>(false).Find("Fist").gameObject != null) SetActive(true);
        else SetActive(false);
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
