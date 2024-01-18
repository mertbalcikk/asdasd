using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;    
    private SpriteRenderer sprite;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpspeed = 14f;
    [SerializeField] private int maxJumps = 2;
    private int JumpsRemaining = 2;
    [SerializeField] private AudioSource JumpSoundEffect;
    


    // Start is called before the first frame update
    private void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        JumpsRemaining = maxJumps;
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (dirX * movespeed, rb.velocity.y);

        //    dirY = Input.GetKeyDown("space");
        if (Input.GetKeyDown("space") && JumpsRemaining >0)
        {
            JumpsRemaining--;
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
            JumpSoundEffect.Play();
            UpdateAnimationUpdate();
        }
        UpdateAnimationUpdate();


    }
    private void UpdateAnimationUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (rb.velocity.y > 0f)
        {
            
            anim.SetBool("jumping", true);
            anim.SetBool("falling", false);
            anim.SetBool("double", false);
            if (JumpsRemaining == 0)
            {
                anim.SetBool("double", true);
            }
        }
        else if (rb.velocity.y < 0f)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
            anim.SetBool("double", false);
        }
      
        else
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);
            anim.SetBool("double", false);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            JumpsRemaining = maxJumps;  
            //isjumping = false;  // Zemine çarptýðýnda isjumping'i sýfýrla
            UpdateAnimationUpdate();
        }
    }
}

