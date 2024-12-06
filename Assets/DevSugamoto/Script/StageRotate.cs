using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRotate : MonoBehaviour
{
    private GameObject stage;
    public Vector3 rot;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        stage = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > 19)
        {
            stage.transform.Rotate(rot);
        }
    }
}
