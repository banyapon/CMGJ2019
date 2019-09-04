using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
public class ChangeSceneMod : MonoBehaviour
{
    public float secondchange = 3f;
    public string sceneName = "Level1";
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, m_Controller)){
            StartCoroutine(ChangeScene());
        }
    }
    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(3f);
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
