using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    //private Quaternion targetRot = 60;

    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position = myTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        //Swing();
        
    }

    private void Move()
    {
        if(Input.GetKey("up"))
        {
            position.z += speed*0.2f;
        }
        if(Input.GetKey("right"))
        {
            position.x += speed*0.2f;
        }
        if(Input.GetKey("down"))
        {
            position.z -= speed*0.2f;
        }
        if(Input.GetKey("left"))
        {
            position.x -= speed*0.2f;
        }

        myTransform.position = position;
    }

/*
    private void Swing()
    {
        //up
        //swing
        //back
        if(Input.GetKeyDown("space"))
        {
            myTransform.Rotate (60.0f, 0f, 0f);
        }
        
    }*/
}
