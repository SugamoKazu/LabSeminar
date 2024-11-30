using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public int scoreCount = 0;
    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHit = false;
        //Debug.Log(isHit);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mole")
        {
            //Debug.Log("Hit");
            scoreCount++;

            isHit = true;
            
            
            //Arduinoに振動させる信号を送る
        }
    }

}
