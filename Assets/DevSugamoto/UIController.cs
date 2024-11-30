using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextTime;
    [SerializeField] private TextMeshProUGUI TextScore;
    [SerializeField] private TextMeshProUGUI TextScoreSub;

    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject MenuCanvas;

    private float elapsedTime;
    public int timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        ActivateOnlyStart();

        
        Debug.Log(Time.timeScale);
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Time.timeScale);
        
        TimeLimit();
        Score();
        
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
            //Debug.Log("Fin");
            Time.timeScale = 0;
            
            MenuCanvas.SetActive(true);

            //SceneManager.LoadScene("WhackAMole");
        }
    }

    private void Score()
    {
        CollisionDetect DetectScript; //呼ぶスクリプトにあだなつける
        GameObject obj = GameObject.Find("Head"); //オブジェクトを探す
        DetectScript = obj.GetComponent<CollisionDetect>(); //付いているスクリプトを取得
        var score = DetectScript.scoreCount;
        TextScore.text = string.Format("Score " + score + " pts");
        TextScoreSub.text = string.Format("Score " + score + " pts");
    }

    public void ActivateOnlyStart()
    {
        StartCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
    }
}
