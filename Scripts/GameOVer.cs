using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
public class GameOVer : MonoBehaviour
{
    public TextMesh ScoreText;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    public string ScorePoint;
    void Start(){
        ScorePoint = PlayerPrefs.GetString("ScorePont");
        ScoreText.text = "YOUR SCORE: "+ScorePoint;
        
    }
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, m_Controller)){
            StartCoroutine(ChangeScene());
        }
    }
    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(0.1f);
			SceneManager.LoadScene("Title", LoadSceneMode.Single);
	}
}
