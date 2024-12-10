using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ButtonText;
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject MenuCanvas;
    //[SerializeField] Button button;


    // Start is called before the first frame update
    public void OnClickButton()
    {
        
        if(ButtonText.text == "RETRY")
        {
            SceneManager.LoadScene("WhackAMole");
        }
        if(ButtonText.text == "START")
        {
            //Time.timeScale = 1;
            StartCanvas.SetActive(false);
            GameCanvas.SetActive(true);
        }
        if(ButtonText.text == "PAUSE")
        {
            Debug.Log("Click");
            Time.timeScale = 0;
            GameCanvas.SetActive(false);
            MenuCanvas.SetActive(true);
        }
        if(ButtonText.text == "×")
        {
            Time.timeScale = 1;
            GameCanvas.SetActive(true);
            MenuCanvas.SetActive(false);
        }

        
    } 
}
