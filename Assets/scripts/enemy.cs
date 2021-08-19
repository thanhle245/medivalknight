using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator ani;
    private Rigidbody2D rb;
    private string currnetState;
    private float countDown;
    private bool Turn;

   
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Turn = true;

      
    }

    void ChangeAnimationState(string newState)
    {
        if (currnetState == newState) return;
        ani.Play(newState);
        currnetState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown<=0)
        {
            countDown = 2f;
            if(Turn)
            {
                Turn = false;
            }
            else
            {
                Turn = true;
            }
        }
        else
        {
            countDown -= Time.deltaTime;
        }

        if (Turn)
        {
            ChangeAnimationState("Slime_moving");
            transform.Translate(Time.deltaTime * 2, 0, 0);
            transform.localScale = new Vector3(6F, 6F, 0);
        }
        else
        {
            ChangeAnimationState("Slime_moving");
            transform.Translate(Time.deltaTime * -2, 0, 0);
            transform.localScale = new Vector3(-6F, 6F, 0);
        }
    }

     void FixedUpdate() {
        
    }

    
    
}
