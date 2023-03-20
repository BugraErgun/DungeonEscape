using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    [SerializeField] Animator swordArc;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();

    }

   
    public void Run(float move)
    {
        anim.SetFloat("Move", Mathf.Abs(move));
    }
    public void Jump(bool jump)
    {
        anim.SetBool("Jump", jump);
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
        swordArc.SetTrigger("SwordArc");
    }
    public void Death()
    {
        anim.SetTrigger("Death");
    }
}
