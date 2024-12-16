using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDirection : MonoBehaviour
{   
    private Transform CameraTransform;


    // Start is called before the first frame update
    void Start()
    {
        // カメラを取得
        CameraTransform = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        // カメラ方向を計算
        Vector3 lookDir = -(CameraTransform.position - transform.position);
        lookDir.y = 0f; // Y軸回転のみなので、Y成分を0に設定する

        // オブジェクトのY軸のみカメラの方向に向ける
        if (lookDir != Vector3.zero)
        {
            transform.forward = lookDir.normalized;
        }
    }

}
