using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    public float timeRemaining = 20; 
    public TextMesh TimeUp,ScoreText,ComboText;
	float timeExtension = 3f; 
	float timeDeduction = 2f; 
	float totalTimeElapsed = 0;   
	float score = 0f; 
	int combo = 0;
	public bool isGameOver = false;
	public DynamicPrefab _SpawnPoint;
	
	void Start () {
		Time.timeScale = 1;
	}
	

	void Update () {
		if(isGameOver)
			return;      //move out of the function
		
		totalTimeElapsed += Time.deltaTime; 
		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0){
			//isGameOver = true;
			_SpawnPoint.stageLevel = 5;
		}
		else if(timeRemaining <= 60){
			_SpawnPoint.stageLevel = 4;
		}
		else if(timeRemaining <= 90){
			_SpawnPoint.stageLevel = 3;
		}
		else if(timeRemaining <= 120){
			_SpawnPoint.stageLevel = 2;
		}
		else if(timeRemaining <= 150){
			_SpawnPoint.stageLevel = 1;
		}

        if(!isGameOver)    
		{
			TimeUp.text = "TIME LEFT: "+((int)timeRemaining).ToString();
            ScoreText.text = "SCORE: "+((int)score).ToString();
            ComboText.text = "COMBO: "+((int)combo).ToString();
		}

		else
		{
            PlayerPrefs.SetString("ScorePont", ((int)score).ToString());
			StartCoroutine(ChangeScene());
		}
	}

    public void GetItems(){
		combo += 1;
		score += 10 + combo;
    }

	public void CrashCamera(){
        score -= 50;
    }

    public void CrashMonster(){
        //timeRemaining -= timeDeduction;
		combo = 0;
    }

    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(0.1f);
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
	}
}
