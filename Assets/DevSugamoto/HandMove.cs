using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up"))
        {
            position.z += 0.3f;
        }
        if(Input.GetKey("right"))
        {
            position.x += 0.3f;
        }
        if(Input.GetKey("down"))
        {
            position.z -= 0.3f;
        }
        if(Input.GetKey("left"))
        {
            position.x -= 0.3f;
        }

        myTransform.position = position;
        
    }
}
