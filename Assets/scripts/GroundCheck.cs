using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
   public PlayerControll player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<PlayerControll>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }
}
