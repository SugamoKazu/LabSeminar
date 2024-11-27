using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;

    private float elapsedTime;
    public int timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit();
        
    }

    private void TimeLimit()
    {
        elapsedTime += Time.deltaTime;
        var limit = timeLimit - elapsedTime;

        if(limit >= 0)
        {
            TextTime.text = string.Format("Time {0:f0} sec",limit);
        }
        else
        {
            Debug.Log("Fin");
            Time.timeScale = 0;
        }
        
    }
}
