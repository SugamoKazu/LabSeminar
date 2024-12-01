using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSwing : MonoBehaviour
{
    public float rotateSpeed = 1,rotateAngle = 1;
    private float targetAngleX;
    Quaternion targetRotation;
 
    void Update()
    {
        //Rot(-30);
        
        if(Input.GetKey("space"))
        {
            Debug.Log("Swing");
            StartCoroutine(Swing());
            //Rot(0);
        }
        
    }
 
    IEnumerator Swing()
    {
        for(int i = 0; i < 30; i++) Rot(-15);
        
        yield return new WaitForSecondsRealtime(0.25f);
        for(int i = 0; i < 30; i++) Rot(60);

        yield return new WaitForSecondsRealtime(0.25f);
        for(int i = 0; i < 30; i++) Rot(0);
    
    }

    public void Rot(int Angle)
    {      
        Debug.Log(Angle); 
        float targetAngleX = Angle;


        targetRotation = Quaternion.Euler(targetAngleX, 0, 0);
 
        //現在の回転から目標の回転に徐々に移行。
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotateSpeed * Time.deltaTime);
        if (Mathf.Approximately(Quaternion.Angle(transform.localRotation, targetRotation), 0f))
        {
            //等しいと判断されたらターゲットの回転にする
            transform.localRotation = targetRotation;
        } 
    }
}
