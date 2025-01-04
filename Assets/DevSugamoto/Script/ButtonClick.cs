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

    [SerializeField] AudioSource ButtonASound;
    [SerializeField] AudioSource ButtonBSound;
    [SerializeField] AudioSource BGM;


    // Start is called before the first frame update
    public void OnClickButton()
    {
        
        if(ButtonText.text == "RETRY")
        {
            SceneManager.LoadScene("WhackAMole");
            ButtonASound.Play();
        }
        if(ButtonText.text == "START")
        {
            //Time.timeScale = 1;
            StartCanvas.SetActive(false);
            GameCanvas.SetActive(true);

            //ButtonASound.Play();
        }
        if(ButtonText.text == "PAUSE")
        {
            //Debug.Log("Click");
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameCanvas.SetActive(false);
                MenuCanvas.SetActive(true);

                ButtonASound.Play();
                BGM.Pause();
            }
        }
        if(ButtonText.text == "CLOSE")
        {
            Time.timeScale = 1;
            GameCanvas.SetActive(true);
            MenuCanvas.SetActive(false);

            ButtonBSound.Play();
            BGM.UnPause();
        }

        
    } 
}
