using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    public SerialHandler serialHandler;
    private Vector3 angle;
    public GameObject Object;
    private Vector3 _axis = Vector3.forward;

    private Transform _transform;
private void Awake()
{
    // transformに毎回アクセスすると重いので、キャッシュしておく
    _transform = transform;
}

void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string message)
    {
        
        Debug.Log(message);
        

        /*
        string AcX = message.Substring(1, message.IndexOf("Y") - 1); // 追加
        string AcY = message.Substring(message.IndexOf("Y") + 1); // 追加
        AcY = AcY.Substring(0, AcY.IndexOf("Z") - 1); // 追加
        string AcZ = message.Substring(message.IndexOf("Z") + 1); // 追加
        AcZ = AcZ.Substring(0, AcZ.IndexOf("x") - 1); // 追加
        string GyX = message.Substring(message.IndexOf("x") + 1); // 追加
        GyX = GyX.Substring(0, GyX.IndexOf("y") - 1); // 追加
        string GyY = message.Substring(message.IndexOf("y") + 1); // 追加
        GyY = GyY.Substring(0, GyY.IndexOf("z") - 1); // 追加
        string GyZ = message.Substring(message.IndexOf("z") + 1); // 追加
        
        
        Debug.Log("AcX:" + AcX + " AcY:" + AcY + " AcZ:" + AcZ);
        Debug.Log("GyX:" + GyX + " GyY:" + GyY + " GyZ:" + GyZ);
        
        angle = new Vector3(float.Parse(AcX)*90, float.Parse(AcY)*90, float.Parse(AcZ)*90);
		Object.transform.rotation = Quaternion.Euler(angle);
        */

        
        string acAngleX = message.Substring(1, message.IndexOf("Y") - 1); // 追加
        string acAngleY = message.Substring(message.IndexOf("Y") + 1); // 追加

        angle = new Vector3(float.Parse(acAngleX), 0 ,float.Parse(acAngleY));
		Object.transform.rotation = Quaternion.Euler(angle);
        


    }
}
