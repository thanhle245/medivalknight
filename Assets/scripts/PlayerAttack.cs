using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;
 
    public Animator anim;
 
    public Collider2D trigger;
  public Soundmanager sound;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<Soundmanager>();
    }
 
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackdelay = 0.75f;
            sound.Playsound("sword");
        }
 
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
 
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
 
        anim.SetBool("Attacking", attacking);
    }

     void OnTriggerEnter2D(Collider2D colli) {
        if(colli.gameObject.tag == "tag_left"){
            Destroy(GameObject.Find("warrior"));
        }
        if(colli.gameObject.tag == "tag_top"){
            Destroy(GameObject.Find("slime"));
        }
    }
}
