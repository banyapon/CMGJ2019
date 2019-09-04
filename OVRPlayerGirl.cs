using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OVRPlayerGirl : MonoBehaviour
{
    Animation animation;
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToFitness(){
        animation.Play("VRRotate");
    }

}
