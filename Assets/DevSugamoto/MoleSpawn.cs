using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawn : MonoBehaviour
{
    private Transform myTransform;
    private Vector3 position;
    public GameObject Mole;
    public GameObject[] SpawnPoints = new GameObject[9];

    private int interval = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int rnd = Random.Range(0,9);
        interval++;
        if((interval%300) == 1) //難易度調整による変更の余地あり
        {
            Instantiate(Mole,SpawnPoints[rnd].transform);
            
        }
    }
}
