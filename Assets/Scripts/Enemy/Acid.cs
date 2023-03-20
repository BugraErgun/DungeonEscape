using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f); 
    }

    void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime*2);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();
            if (hit != null) 
            { 
                hit.Damage();
                Destroy(this.gameObject);
            }
           
        }
    }

    
}
