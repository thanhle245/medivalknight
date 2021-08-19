using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class control : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        // if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        // {
        //     isGrounded = true;
        // }else{
        //     isGrounded = false;
        // }
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector3(runSpeed , rb2d.velocity.y);
            animator.Play("run");
            spriteRenderer.flipX=false;
        }
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector3(-runSpeed ,  rb2d.velocity.y);
            animator.Play("run");
            spriteRenderer.flipX=true;
        }
        else
        {
            
            animator.Play("stay");
            rb2d.velocity = new Vector3(0 ,  rb2d.velocity.y); 
        }

        if( Input.GetKey("up") /*&& isGrounded*/ )
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x , jumpSpeed);
            animator.Play("jump");
        }

        

        // if(Input.GetKey("space") )
        // {
        //     rb2d.velocity = new Vector3(0 , rb2d.velocity.y);
        //     animator.Play("attack");
        // }
    }
}
