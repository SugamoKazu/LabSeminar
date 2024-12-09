using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position,rotation;
    //private Quaternion targetRot = 60;

    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position = myTransform.position;
        rotation = myTransform.localEulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Twist();
        
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

        if(Input.GetKeyDown("s"))//リセット動作　←　ボタンで動作？
        {
            position -= myTransform.position;
            myTransform.localEulerAngles = rotation;
            
        }


        myTransform.position = position;
    }

    private void Twist()
    {
        if(Input.GetKey("a"))
        {
            myTransform.Rotate(0,0,3f);
        }
        if(Input.GetKey("d"))
        {
            myTransform.Rotate(0,0,-3f);
        }
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
