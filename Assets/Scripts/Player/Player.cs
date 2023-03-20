using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamageable
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField]float jumpForce;
    [SerializeField] LayerMask layerMask;
    private bool resetJump = false;
    private bool grounded = false;
    SpriteRenderer spriteRenderer;
    PlayerAnimation playerAnimation;

    public int diamonds;


    private SpriteRenderer swordArcSpriteRenderer;

    public int Health { get; set; }

    void Start()
    {
        swordArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        spriteRenderer =GetComponentInChildren<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody2D>();
        Health = 4;
    }

    void Update()
    {
        Movement();
        if ( CrossPlatformInputManager.GetButtonDown("A_Btn") && IsGrounded())
        {
            playerAnimation.Attack();
        }
    }
    void Movement()
    {
        float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        grounded = IsGrounded();
        Flip(horizontal);

        if ( CrossPlatformInputManager.GetButtonDown("B_Btn") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            StartCoroutine(ResetJumpRoutine());
            playerAnimation.Jump(true);

        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        playerAnimation.Run(horizontal);
    }
    private void Flip(float move)
    {
        if (move < 0)
        {
           
            spriteRenderer.flipX = true;

            swordArcSpriteRenderer.flipX = true;
            swordArcSpriteRenderer.flipY = true;
            Vector3 newPos = swordArcSpriteRenderer.transform.localPosition;
            newPos.x = -1.01f;
            swordArcSpriteRenderer.transform.localPosition = newPos;
        }
        else if (move > 0)
        {
            spriteRenderer.flipX = false;

            swordArcSpriteRenderer.flipX = false;
            swordArcSpriteRenderer.flipY = false;
            Vector3 newPos = swordArcSpriteRenderer.transform.localPosition;
            newPos.x = 1.01f;
            swordArcSpriteRenderer.transform.localPosition= newPos;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask.value);
        if (hit.collider != null)
        {
            if (!resetJump)
            {
                playerAnimation.Jump(false);
                return true; 
            }
        }
        
        return false;
    }
    
    IEnumerator ResetJumpRoutine()
    {
       
        resetJump = true;
        yield return new WaitForSeconds(.15f);
        resetJump = false;
    }

    public void Damage()
    {
        if (Health< 1)
        {
            return;
        }
        Debug.Log("player damage");
        Health--;
        UIManager.UIinstance.UpdateHealthBar(Health);
        if (Health < 1)
        {
            playerAnimation.Death();
        }
    }
    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.UIinstance.UpdateGemCount(diamonds);
    }
}
