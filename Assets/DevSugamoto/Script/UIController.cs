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
    
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource FinishSound;
    
    private float elapsedTime;
    public int timeLimit, StateNum;
    public SerialHandler serialHandler;
    private string[] data;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        ActivateOnlyStart();

        StateNum = 0;
        
        //Debug.Log(Time.timeScale);
        Time.timeScale = 0;
        serialHandler.OnDataReceived += OnDataReceived;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeScale);
        //Button();
        TimeLimit();
        Score();
        
    }

    void Button()
    {
        if(StateNum == 0)
        {
            if(data[0] == "Reset")
            {
                Buttons[0].onClick.Invoke();
                StateNum = 1;

            }
        }
        else if(StateNum == 1)
        {
            if(data[0] == "UI")
            {
                if(Time.timeScale == 1)
                {
                    StateNum = 2;
                    Buttons[1].onClick.Invoke();
                }
            }
        }
        else if(StateNum == 2)
        {
            if(data[0] == "Reset")
            {
                Buttons[2].onClick.Invoke();
                StateNum = 0;

            }
            if(data[0] == "Up")
            {
                Buttons[3].onClick.Invoke();
                StateNum = 1;
            }
        }
        else
        {
            if(data[0] == "Reset")
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

        if(limit >= 0.5)
        {
            TextTime.text = string.Format("{0:f0} s",limit);
        }
        else if(limit < 0.5 && limit > 0)
        {
            FinishSound.Play();
        }
        else
        {
            //Debug.Log("Fin");

            TextTime.text = string.Format("0 s");
            Time.timeScale = 0;
            StateNum = 3;
            MenuCanvas.SetActive(true);
            GameCanvas.SetActive(false);


            BGM.Stop();

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
    void OnDataReceived(string message)
    {
        //Debug.Log(message);
        data = message.Split(
            new string[]{"\n"}, System.StringSplitOptions.None);
    }
}
