using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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

    [SerializeField] Button[] Buttons;

    private float elapsedTime;
    public int timeLimit, StateNum;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        ActivateOnlyStart();

        StateNum = 0;
        
        //Debug.Log(Time.timeScale);
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeScale);
        Button();
        TimeLimit();
        Score();
        
    }

    void Button()
    {
        if(StateNum == 0)
        {
            if(Input.GetKeyDown("s"))
            {
                Buttons[0].onClick.Invoke();
                StateNum = 1;
            }
        }
        else if(StateNum == 1)
        {
            if(Input.GetKeyDown("b"))
            {
                StateNum = 2;
                Buttons[1].onClick.Invoke();
            }
        }
        else if(StateNum == 2)
        {
            if(Input.GetKeyDown("s"))
            {
                Buttons[2].onClick.Invoke();
                StateNum = 0;
            }
            if(Input.GetKeyDown("b"))
            {
                Buttons[3].onClick.Invoke();
                StateNum = 1;
            }
        }
        else
        {
            if(Input.GetKeyDown("s"))
            {
                Buttons[2].onClick.Invoke();
                StateNum = 0;
            }
        }
        
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
            StateNum = 3;
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
