using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawn : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    public GameObject Mole;
    public GameObject[] SpawnPoints = new GameObject[9];

    private int interval, count;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int rnd = Random.Range(0,9);
        count++;

        interval = 30*Mathf.FloorToInt((Mathf.Pow(count/60,2))/900 - count/450 + 5);
        Debug.Log(interval);

        var Spawn = 1 + (300 - interval)/60;

        if((count%interval) == 1) //難易度調整による変更の余地あり
        {
            for(int i = 0; i < Spawn; i++)
            {
                //Debug.Log(SpawnPoints[rnd].transform.childCount);

                if(SpawnPoints[rnd].transform.childCount == 0)
                {
                    Instantiate(Mole,SpawnPoints[(rnd + i)%9].transform);
                }
                
            }
        }
        
    }
}
