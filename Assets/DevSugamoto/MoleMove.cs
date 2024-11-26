using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    private int moveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        position = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveCount++;
        var moveVec = 0.1f;

        if(40 < moveCount && moveCount < 120) //停止時間を動的に？
        {
            moveVec *= 0;
        }
        else if(120 < moveCount)
        {
            moveVec *= -2;
        }


        Debug.Log(moveVec);
        position.y += moveVec;

        if(moveCount == 140) //難易度調整の余地あり
        {
            Destroy(this.gameObject);
        }

        myTransform.position = position;


    }
}
