using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
public class Ending : MonoBehaviour
{
    public TextMesh UIText,StartText;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    
	public string TextToType,TextToType2,TextToType3;
    public int step = 0;
    public float TimeToType = 3.0f;
	public bool endWord = false;
    private float textPercentage = 0f;
    public string sceneName = "Title";
    void Start()
    {
        StartText.text ="";
        TextToType ="Man:\n\n Things aren’t \nworking out between us anymore.";
    }


    // Update is called once per frame
    void Update()
    {
        callTyping(TextToType);
        
            if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
                step = step +1;
                callTyping(TextToType);
                textPercentage = 0f;
                endWord = false;
            }

        
        if(step >= 6){
            step = 6;
        }
        switch (step)
        {
            case 6:
                TextToType ="Woman:\n\n Thank you For Playing this VR Game";
                callTyping(TextToType);
                StartCoroutine(ChangeScene());
                break;
            case 5:
                TextToType ="...";
                callTyping(TextToType);
                break;
            case 4:
                TextToType = "Woman:\n\n Good\nLuck";
                callTyping(TextToType);
                break;
            case 3:
                TextToType = "Woman:\n\n Now, I'm dating someone.";
                callTyping(TextToType);
                break;
            case 2:
                TextToType = "Woman:\n\n It’s time that \nwe start seeing other people.";
                callTyping(TextToType);
                break;
            case 1:
                TextToType = "Woman:\n\n You Right!";
                callTyping(TextToType);
                break;
            default:
                TextToType = "Woman:\n\n I'm a new girl. \nI'm not playing that game any more.";
                callTyping(TextToType);
                break;
        }
    }

    void callTyping(string TextToType){
		int numberOfLettersToShow = (int)(TextToType.Length * textPercentage);
		UIText.text = TextToType.Substring(0, numberOfLettersToShow);
		textPercentage += Time.deltaTime / TimeToType;
		textPercentage = Mathf.Min(1.0f, textPercentage);
		//Debug.Log("%: "+textPercentage);
		if(textPercentage >= 1){
			endWord = true;
		}
	}

    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(3f);
			SceneManager.LoadScene("Title", LoadSceneMode.Single);
	}
}
