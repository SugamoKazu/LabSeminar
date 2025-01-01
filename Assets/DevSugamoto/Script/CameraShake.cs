using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    public float shakeRange;
    private int ShakeCount;
    public SerialHandler serialHandler; // SerialHandlerのインスタンスを取得
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CollisionDetect DetectScript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Head"); //オブジェクトを探す
        DetectScript = obj.GetComponent<CollisionDetect>(); //付いているスクリプトを取得
        
        //Debug.Log(DetectScript.isHit);
        if(DetectScript.isHit){
            ShakeCount = 16;
            serialHandler.Write("1");
        }
        if(ShakeCount > 0)
        {

            if(ShakeCount%4 == 0)
            {
                Camera.transform.Rotate(0,shakeRange,0f,0f);
                shakeRange *= -1;
            }
            ShakeCount--;
        }
        
    }
}
