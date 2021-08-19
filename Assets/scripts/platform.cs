using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platform : MonoBehaviour
{
    private Vector3 PosA;
    private Vector3 PosB;
    private Vector3 nextPos;

    [SerializeField]
    public float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;
    // Start is called before the first frame update
    void Start()
    {
        PosA = childTransform.localPosition;
        PosB = transformB.localPosition;
        nextPos = PosB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move(){
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition,nextPos,speed*Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition,nextPos) <=0.1){
            changeDestination();
        }
    }
    
    public void changeDestination(){
        nextPos =nextPos != PosA ? PosA : PosB;
    }
}
