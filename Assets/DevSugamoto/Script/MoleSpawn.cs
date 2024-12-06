using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawn : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    public GameObject Mole;
    public GameObject MoleG;
    public GameObject[] SpawnPoints;

    private int interval, count, num;
    // Start is called before the first frame update
    void Start()
    {
        num = SpawnPoints.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int rnd = Random.Range(0,num);
        count++;

        interval = 60*Mathf.FloorToInt((Mathf.Pow(count/60,2))/900 - count/450 + 5);
        //Debug.Log(interval);

        var Spawn = 1 + (300 - interval)/60;

        if(count%300 == 1 && count > 1800)
        {
            //Debug.Log("Gold");
            if(SpawnPoints[4].transform.childCount == 0) Instantiate(MoleG,SpawnPoints[4].transform);
            else
            {
                for(int i = 1; i < 5 ; i++)
                {
                    if(SpawnPoints[4+i].transform.childCount == 0)
                    {
                        Instantiate(MoleG,SpawnPoints[4+i].transform);
                        i = 4;
                    }
                    else if(SpawnPoints[4-i].transform.childCount == 0)
                    {
                        Instantiate(MoleG,SpawnPoints[4-i].transform);
                        i = 4;
                    }

                }
            }
            
        }

        if((count%interval) == 1) //難易度調整による変更の余地あり
        {
            //Debug.Log("Spawn" + interval);
            for(int i = 0; i < Spawn; i++)
            {
                if(SpawnPoints[(rnd + 5*i)%num].transform.childCount == 0) Instantiate(Mole,SpawnPoints[(rnd + 5*i)%9].transform);
                else if(SpawnPoints[(rnd + 5*i + 2)%num].transform.childCount == 0) Instantiate(Mole,SpawnPoints[(rnd + 5*i + 2)%num].transform);
            }
        }

        
        
    }
}
