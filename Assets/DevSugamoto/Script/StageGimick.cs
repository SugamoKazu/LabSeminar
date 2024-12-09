using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGimick : MonoBehaviour
{
    private Transform myTransform;
    public Transform GimickMarker;

    public float speed = 1.0F;
    private float distance_two, elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //20秒たったら移動
        elapsedTime += Time.deltaTime;
        distance_two = Vector3.Distance(myTransform.position, GimickMarker.position);

        if(elapsedTime > 18)
        {
            float present_Location = ((elapsedTime - 18) * speed) / distance_two;
            transform.position = Vector3.Lerp(myTransform.position, GimickMarker.position, present_Location);
        }
    }
}
