using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
public class Dialog : MonoBehaviour
{
    public TextMesh UIText,StartText;
    public GameObject man1,woman1, manwalk, womanwalk;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    
	public string TextToType,TextToType2,TextToType3;
    public int step = 0;
    public float TimeToType = 3.0f;
	public bool endWord = false;
    private float textPercentage = 0f;
    public string sceneName = "Level1";
    void Start()
    {
        man1.SetActive(true);
        woman1.SetActive(true);
        manwalk.SetActive(false);
        womanwalk.SetActive(false);
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

        
        if(step >= 10){
            step = 10;
        }
        switch (step)
        {
            case 10:
                TextToType ="Oh!!!!";
                callTyping(TextToType);
                man1.SetActive(false);
                manwalk.SetActive(false);
                woman1.SetActive(false);
                womanwalk.SetActive(true);
                StartText.text= "Press A of X Button to start";
                StartCoroutine(ChangeScene());
                break;
            case 9:
                TextToType ="Woman: \n\n This will haunt me \nforever.";
                callTyping(TextToType);
                man1.SetActive(false);
                manwalk.SetActive(true);
                break;
            case 8:
                TextToType ="Man:\n\n Bye.";
                callTyping(TextToType);
                break;
            case 7:
                TextToType ="Man:\n\n We should probably \nbreak up.";
                callTyping(TextToType);
                break;
            case 6:
                TextToType ="Woman:\n\n No No No!!, \nPlease.....?!!!";
                callTyping(TextToType);
                break;
            case 5:
                TextToType ="Man:\n\n I’m not good enough \nfor you.";
                callTyping(TextToType);
                break;
            case 4:
                TextToType = "Man:\n\n It’s not you, it’s me.\n You’re too good for me.";
                callTyping(TextToType);
                break;
            case 3:
                TextToType = "Woman:\n\n What?!!!";
                callTyping(TextToType);
                break;
            case 2:
                TextToType = "Man:\n\n It’s time that \nwe start seeing other people.";
                callTyping(TextToType);
                break;
            case 1:
                TextToType = "Woman:\n\n Why?";
                callTyping(TextToType);
                break;
            default:
                TextToType = "Man:\n\n Things aren’t \nworking out between us anymore.";
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
			yield return new WaitForSeconds(1f);
			SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}


}