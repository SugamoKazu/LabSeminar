using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextCountdown;

    [SerializeField] AudioSource CountdownSound;
    [SerializeField] AudioSource BGM;

    // Start is called before the first frame update
    public  void ClickStart()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        Time.timeScale = 0;
        
        CountdownSound.Play();

        TextCountdown.text = "3";
		yield return new WaitForSecondsRealtime(1.0f);

		TextCountdown.text = "2";
		yield return new WaitForSecondsRealtime(1.0f);
 
		TextCountdown.text = "1";
		yield return new WaitForSecondsRealtime(1.0f);
		
		TextCountdown.text = "GO!";
		yield return new WaitForSecondsRealtime(1.0f);
        
        TextCountdown.text = null;
        Time.timeScale = 1;
        BGM.Play();
    } 
}
