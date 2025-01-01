using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectController : MonoBehaviour
{
    public SerialHandler serialHandler;
    public float time_speed = 100f;
    public static float dt = 1.0f;
    public float delta = 1;
    private float deltaPos;
    private    Vector3 pos;
    private Quaternion to_qua;
    private Quaternion standard;
    int i = 0;
    private static int q_counter = 1;
    private float b1AcX = 0,b2AcX = 0,b3AcX = 0,b4AcX = 0,b1AcY = 0,b2AcY = 0,b3AcY = 0,b4AcY = 0,b1AcZ = 0,b2AcZ = 0,b3AcZ = 0,b4AcZ = 0;
    private float b1GyX = 0,b2GyX = 0,b3GyX = 0,b4GyX = 0,b1GyY = 0,b2GyY = 0,b3GyY = 0,b4GyY = 0,b1GyZ = 0,b2GyZ = 0,b3GyZ = 0,b4GyZ = 0;
    private float aveAcX=0,aveAcY=0,aveAcZ=0,aveGyX=0,aveGyY=0,aveGyZ=0;

void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string message)
    {
        Debug.Log(message);

        Vector3 pos = this.transform.position;
        var data = message.Split(
            new string[]{"\n"}, System.StringSplitOptions.None);

        switch(data[0]){
            case "Reset":
                this.transform.rotation = Quaternion.Euler(0,0,0);
                break;
            case "Up":
                deltaPos = delta * 1;
                pos.z += deltaPos;
                break;
            case "Down":
                deltaPos = delta * -1;
                pos.z += deltaPos;
                break;
            case "Left":
                deltaPos = delta * -1;
                pos.x += deltaPos;
                break;
            case "Right":
                deltaPos = delta * 1;
                pos.x += deltaPos;
                break;
            default:
                string AccX = message.Substring(1, message.IndexOf("Y") - 1); // 追加
                string AccY = message.Substring(message.IndexOf("Y") + 1); // 追加
                AccY = AccY.Substring(0, AccY.IndexOf("Z") - 1); // 追加
                string AccZ = message.Substring(message.IndexOf("Z") + 1); // 追加
                AccZ = AccZ.Substring(0, AccZ.IndexOf("x") - 1); // 追加
                string GyroX = message.Substring(message.IndexOf("x") + 1); // 追加
                GyroX = GyroX.Substring(0, GyroX.IndexOf("y") - 1); // 追加
                string GyroY = message.Substring(message.IndexOf("y") + 1); // 追加
                GyroY = GyroY.Substring(0, GyroY.IndexOf("z") - 1); // 追加
                string GyroZ = message.Substring(message.IndexOf("z") + 1); // 追加

                float AcX = float.Parse(AccX);
                float AcY = float.Parse(AccY);
                float AcZ = float.Parse(AccZ);
                float GyX = float.Parse(GyroX);
                float GyY = float.Parse(GyroY);
                float GyZ = float.Parse(GyroZ);

                //加速度の加重移動平均
                aveAcX = (5*AcX + 4*b1AcX + 3*b2AcX + 2*b3AcX + b4AcX) / 15;
                aveAcY = (5*AcY + 4*b1AcY + 3*b2AcY + 2*b3AcY + b4AcY) / 15;
                aveAcZ = (5*AcZ + 4*b1AcZ + 3*b2AcZ + 2*b3AcZ + b4AcZ) / 15;
                

                //角速度の加重移動平均
                aveGyX = (5*GyX + 4*b1GyX + 3*b2GyX + 2*b3GyX + b4GyX) / 15;
                aveGyY = (5*GyY + 4*b1GyY + 3*b2GyY + 2*b3GyY + b4GyY) / 15;
                aveGyZ = (5*GyZ + 4*b1GyZ + 3*b2GyZ + 2*b3GyZ + b4GyZ) / 15;

                Vector3 GyroVec = new Vector3(aveGyX/5,-aveGyZ/100,-aveGyY/100);
                Vector3 AccVec = new Vector3(aveAcY/10,-aveAcZ*0,aveAcX/10);

                to_qua = this.transform.rotation * Quaternion.Euler(GyroVec * dt);
                standard = this.transform.rotation;

                this.transform.rotation = Quaternion.Slerp(standard, to_qua, Time.deltaTime * time_speed);

                //値の更新
                b4AcX = b3AcX; b4AcY = b3AcY; b4AcZ = b3AcZ;
                b4GyX = b3GyX; b4GyY = b3GyY; b4GyZ = b3GyZ;

                b3AcX = b2AcX; b3AcY = b2AcY; b3AcZ = b2AcZ;
                b3GyX = b2GyX; b3GyY = b2GyY; b3GyZ = b2GyZ;

                b2AcX = b1AcX; b2AcY = b1AcY; b2AcZ = b1AcZ;
                b2GyX = b1GyX; b2GyY = b1GyY; b2GyZ = b1GyZ;

                b1AcX = AcX; b1AcY = AcY; b1AcZ = AcZ;
                b1GyX = GyX; b1GyY = GyY; b1GyZ = GyZ;
                break;
        }
        transform.localPosition = pos;
        

        
        
    }
}
