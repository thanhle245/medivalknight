using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlat : MonoBehaviour
{
    public GameObject shape;
    public GameObject Pos;

    // Start is called before the first frame update
    void Start()
    {
        
             StartCoroutine(connect());

        IEnumerator connect(){
            yield return new WaitForSeconds(4);
            Vector3 temp = Pos.transform.position;
        temp.x = Random.Range(92f,116f);
        

        Instantiate(shape,temp,Quaternion.identity);
        StartCoroutine(connect());
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
}
