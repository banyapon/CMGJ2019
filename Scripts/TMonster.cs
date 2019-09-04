using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMonster : MonoBehaviour
{
    float objectSpeed = 0.1f;
    public float SecondsUntilDestroy = 5f;
    public AudioSource Punch;
    public GameLogic gameLogic;
	float startTime;
    public GameObject clearMonster;

    void Start () {
		startTime = Time.time;
        
	}

    void Update()
    {
        transform.Translate(0, 0, objectSpeed);
        if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy(this.gameObject);
		}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /* 
       if(other.gameObject.tag == "LPunch"){
           if(!other.gameObject.GetComponent<LeftPunch>().inOffTrigger)
           {
                //gameLogic.GetItems();
                Punch.Play();
                Instantiate(clearMonster, transform.position, transform.rotation);
                Destroy(this.gameObject);
           }
       }
       */
       if(other.gameObject.tag == "MainCamera" || other.gameObject.tag == "RPunch" || other.gameObject.tag == "LPunch"){
           this.gameObject.GetComponent<BoxCollider>().enabled = false;
           gameLogic.CrashCamera();
           //Instantiate(clearMonster, transform.position, transform.rotation);
		   //Destroy(this.gameObject);
       }
       
       if(other.gameObject.tag == "Player"){
           //Instantiate(clearMonster, transform.position, transform.rotation);
		   Destroy(this.gameObject);
       }
    }
}
