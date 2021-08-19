using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControll : MonoBehaviour
{
   public float speed = 50f, maxspeed = 10, jumpPow = 250f;
    public bool grounded = true, faceright = true, doublejump = false;
    
    public int ourHealth;
    public int maxhealth = 5;

    public Rigidbody2D r2;
    public Animator anim;
    public GameMaster gm;
    public Soundmanager sound;
	// Use this for initialization
	void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<GameMaster>();
         ourHealth = maxhealth;
         sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Soundmanager>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            { 
                grounded = false;
                r2.AddForce(Vector2.up * jumpPow);
            }
             else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 3f);
                }
            }
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        
        if (h>0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
         if (ourHealth <= 0)
        {
            Death();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
     public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("hurt");
    }
 
    public void Knockback (float Knockpow, Vector2 Knockdir)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -100, Knockdir.y * Knockpow));
    }
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
            sound.Playsound("sword");
        }
    }
}
