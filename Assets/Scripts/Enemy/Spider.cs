using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] GameObject spiderAcid;
   
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public override void Update()
    {
        
    }
    public void Damage()
    {
        Health--;
        if (Health<1)
        {
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    
    public override void Movement()
    {
        
    }
    public void Attack()
    {
        Instantiate(spiderAcid, transform.position, Quaternion.identity);
    }
}
