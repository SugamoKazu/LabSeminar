using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    private int moveCount = 0;

    public int stay;
    public bool isMole = false;

    CapsuleCollider Cap;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.transform.parent = null;

        myTransform = this.transform;
        position = myTransform.localPosition;

        Cap = GetComponent<CapsuleCollider>();

        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveCount++;
        var moveVec = 0.1f;

        if(40 < moveCount && moveCount < 40 + stay) //停止時間を動的に？
        {
            moveVec *= 0;
        }
        else if(40 + stay < moveCount)
        {
            moveVec *= -4;
        }


        //Debug.Log(moveVec);
        position.y += moveVec;

        if(moveCount == 40 + stay + 20) //難易度調整の余地あり
        {
            Destroy(this.gameObject);
        }

        myTransform.localPosition = position;


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hammer")
        {
            //Debug.Log("Down");
            myTransform.localScale = new Vector3(1, 0.2f, 1);
            
            //Cap.enabled = false;
            Cap.radius = 0.2f;
            //Cap.height = 0.0f;

            //moveCount += 60;
        }
    }
    
}
