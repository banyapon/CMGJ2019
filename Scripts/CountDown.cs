using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float currCountdownValue;
    public GameObject SpawnPoint;
    public TextMesh textReady,textCountDown;
    public AudioSource idoMybest,Rocky,ThemeSong;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SpawnPoint.SetActive(false);
        StartCoroutine(StartCountdown());
        Rocky.Play();
    }

    public IEnumerator StartCountdown(float countdownValue = 9)
    {
        currCountdownValue = countdownValue;
        
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }

    void Update(){
        if(currCountdownValue <= 0){
            textCountDown.text = "";
            idoMybest.Play();
            SpawnPoint.SetActive(true);
            ThemeSong.volume=1;
        }else{
            textReady.text = "";
            textCountDown.text = ""+currCountdownValue;
        }
    }
}