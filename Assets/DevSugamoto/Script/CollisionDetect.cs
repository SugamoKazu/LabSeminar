using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField] AudioSource HitSound;

    public int scoreCount = 0, ShakeTime = 0;
    public bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isHit);

        
        if(ShakeTime > 0)
        {
            isHit = true;
            ShakeTime--;
            
            HitSound.Play();

        }
        else
        {
            isHit = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Mole")
        {
            //Debug.Log("Hit");
            
            HitSound.pitch = Random.Range(0.85f,0.90f);

            scoreCount++;
            isHit = true;
            
            
            //Arduinoに振動させる信号を送る
        }
        if(other.gameObject.tag == "MoleG")
        {
            //Debug.Log("Hit");
            
            HitSound.pitch = Random.Range(1.0f,1.05f);

            scoreCount += 3;
            isHit = true;
            
            
            //Arduinoに振動させる信号を送る
        }
        ShakeTime = 1;
    }

}
