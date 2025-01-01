using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SerialSend : MonoBehaviour
{
    /*
    //SerialHandler.cのクラス
    public SerialHandler serialHandler;
    CollisionDetect DetectScript; //呼ぶスクリプトにあだなつける
    GameObject obj = GameObject.Find("Head"); //オブジェクトを探す
    DetectScript = obj.GetComponent<CollisionDetect>(); //付いているスクリプトを取得

    void Update()
    {
        if(DetectScript.isHit == true){
            onoff = true;
        }else{
            onoff = false;
        }
        if(onoff){
            usendmsg();
        }else{
            dsendmsg();
        }
        
    }

    void usendmsg()
    {
        if (cansend == true)            //送信可能かチェック
        {
            serialHandler.Write("1");   //Arduinoに1を送信
            Debug.Log("1を送信");
            cansend = false;            //オフになるまで送信不可に設定
        }
    }

    //オフ用メソッド
    void dsendmsg()
    {
        if (cansend == false)           //送信可能かチェック
        {
            cansend = true;             //オフになるまで送信不可に設定
        }
    }
    */
}