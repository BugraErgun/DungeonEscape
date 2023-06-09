using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer spriteRenderer;

    protected bool isHit = false;

    protected Player player;
    public virtual void Init()
    {
        player = GameObject.FindObjectOfType<Player>();
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false
            || anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return;
        }
        else
        {
            Movement();
        }
    }
    
    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {

            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (transform.position == pointA.position)
        {

            currentTarget = pointB.position;
            anim.SetTrigger("Idle");


        }
        else if (transform.position == pointB.position)
        {

            currentTarget = pointA.position;
            anim.SetTrigger("Idle");


        }
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            
        }
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance>=2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
            
        }
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            transform.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            transform.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }

    }
   
}
