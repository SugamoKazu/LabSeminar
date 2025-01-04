using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScale : MonoBehaviour
{
    private Vector3 defaultScale;
    public Vector3 targetScale = Vector3.one * 2f; // 目標の拡大率
    public float scaleSpeed = 2f; // 拡大・縮小速度

    private int ScaleSize;

    // Start is called before the first frame update
    void Start()
    {
        defaultScale = this.transform.localScale;
        ScaleSize = 1;
    }

    void Update()
    {
        switch (ScaleSize)
        {
            case 0:
                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime); // ラープで拡大・縮小
                break;
            case 1:
                transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, scaleSpeed * Time.deltaTime); // ラープで拡大・縮小
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mole" || other.gameObject.tag == "MoleG")
        {
            ScaleSize = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Mole" || other.gameObject.tag == "MoleG" )
        {
            ScaleSize = 1;
        }
    }

}
