using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    public SerialHandler serialHandler;
    private Vector3 angle;
    public GameObject Object;
    [SerializeField] private Vector3 _acceleration;

    public float time_speed = 10f;
    public static float dt = 1.0f;
    //private static float t = 1;

    private Quaternion to_qua;
    private Quaternion standard;

    int i = 0;

    private static int q_counter = 1;
void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }


    void OnDataReceived(string message)
    {
        
        Debug.Log(message);
        
        
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
        
        /*
        Debug.Log("AcX:" + AcX + " AcY:" + AcY + " AcZ:" + AcZ);
        Debug.Log("GyX:" + GyX + " GyY:" + GyY + " GyZ:" + GyZ);
        

        angle = new Vector3(float.Parse(AcX)*90, float.Parse(AcY)*90, float.Parse(AcZ)*90);
		Object.transform.rotation = Quaternion.Euler(angle);
        */

        /*
        string AngleX = message.Substring(1, message.IndexOf("P") - 1); // 追加
        string AngleY = message.Substring(message.IndexOf("P") + 1); // 追加
        AngleY = AngleY.Substring(0, AngleY.IndexOf("x") - 1); // 追加
        string AcX = message.Substring(message.IndexOf("x") + 1); // 追加
        AcX = AcX.Substring(0, AcX.IndexOf("y") - 1); // 追加
        string AcY = message.Substring(message.IndexOf("y") + 1); // 追加
        AcY = AcY.Substring(0, AcY.IndexOf("z") - 1); // 追加
        string AcZ = message.Substring(message.IndexOf("z") + 1); // 追加
        */

        //Debug.Log("AcX:" + AcX + " AcY:" + AcY + " AcZ:" + AcZ);
        
        /*
        angle = new Vector3(-float.Parse(AngleX), 0 , -float.Parse(AngleY));
		Object.transform.rotation = Quaternion.Euler(angle);
        */
        
        // 加速度の時間積分から速度を求める
        /*
        _acceleration = new Vector3(float.Parse(AcX)/1000, 0 , 0);
        _rigidbody.AddForce(_acceleration, ForceMode.Acceleration);
        */

        Vector3 GyroVec = new Vector3(-float.Parse(GyY)/10,-float.Parse(GyZ)/10,float.Parse(GyX)/10);
        Vector3 AccVec = new Vector3(float.Parse(AcY)/10,-float.Parse(AcZ)*0,float.Parse(AcX)/10);

        to_qua = this.transform.rotation * Quaternion.Euler(GyroVec * dt);
        standard = this.transform.rotation;

        this.transform.rotation = Quaternion.Slerp(standard, to_qua, Time.deltaTime * time_speed);

        i++;
    }
}
