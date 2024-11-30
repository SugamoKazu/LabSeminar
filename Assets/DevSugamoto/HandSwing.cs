using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSwing : MonoBehaviour
{
    private Vector3 pos;
    private Quaternion rot;
 
    void Update()
    {
        pos = transform.position;
        rot = transform.rotation;
 
        print(rot.x);
        Invoke("BRotate", 0.5f);
    }
 
    void BRotate()
    {
        if (rot.x < 62f)
        {
            transform.Rotate(new Vector3(180, 0, 0) * Time.deltaTime);
        }
    }
}
