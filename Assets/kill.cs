﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D colli)
    {
        if(colli.gameObject.tag == "tag_top"){
            Destroy(GameObject.Find("Slime"));
        }
        
        
    }
}
