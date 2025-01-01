using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESP32Controller : MonoBehaviour
{
    public SerialHandler serialHandler;

    void Start()
    {
        // SerialHandlerのOnDataReceivedイベントにメソッドを追加
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void Update()
    {
        // キー入力に基づいてESP32にデータを送信する
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1キーが押されたとき
        {
            serialHandler.Write("1"); // ESP32に"1"を送信
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) // 0キーが押されたとき
        {
            serialHandler.Write("0"); // ESP32に"0"を送信
        }
    }

    void OnDataReceived(string message)
    {
        Debug.Log("Received from ESP32: " + message);
    }

    void OnDestroy()
    {
        // イベントからメソッドを解除
        serialHandler.OnDataReceived -= OnDataReceived;
    }
}
