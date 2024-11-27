using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMove : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    private int moveCount = 0;

    public int stay;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.parent = null;

        myTransform = this.transform;
        position = myTransform.position;
    }

    // Update is called once per frame
    void Update()
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


        Debug.Log(moveVec);
        position.y += moveVec;

        if(moveCount == 40 + stay + 20) //難易度調整の余地あり
        {
            Destroy(this.gameObject);
        }

        myTransform.position = position;


    }
}
