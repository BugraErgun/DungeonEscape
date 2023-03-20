using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MossGiant : Enemy , IDamageable
{
    public int Health { get; set; }
    
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }
    public override void Movement()
    {
        base.Movement();
    }
    public void Damage()
    {

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        if (!isHit)
        {
            anim.SetBool("InCombat", false);
        }
        else
        {
            anim.SetBool("InCombat", true);
        }
        if (Health <= 0)
        {
            anim.SetTrigger("Death");

            GameObject diamond = Instantiate(diamondPrefab,transform.position,Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
