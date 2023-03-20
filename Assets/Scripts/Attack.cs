using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool canDamage = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit " + collision.gameObject.name);
        IDamageable hit = collision.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (canDamage)
            {
                hit.Damage();
                canDamage= false;
                StartCoroutine(ResetDamage());
            }
            
        }
    }
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(.5f);
        canDamage = true;
    }
}
