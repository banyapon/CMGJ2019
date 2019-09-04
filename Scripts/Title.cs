using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using OVR;
public class Title : MonoBehaviour
{
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One, m_Controller)){
            StartCoroutine(ChangeScene());
        }
    }
    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(1f);
			SceneManager.LoadScene("Story", LoadSceneMode.Single);
	}
}
