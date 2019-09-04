using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    float objectSpeed = 0.1f;
    public float SecondsUntilDestroy = 5f;
    public AudioSource Punch;
    public GameObject clearMonster;
    public GameLogic gameLogic;
	float startTime;

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

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "RPunch" || other.gameObject.tag == "LPunch"){
           //if(other.gameObject.GetComponent<RightPunch>().inOffTrigger)
           //{
               //gameLogic.GetItems();
                Punch.Play();
                Instantiate(clearMonster, transform.position, transform.rotation);
                Destroy(this.gameObject);
           //}
       }
       
       if(other.gameObject.tag == "Player"){
           //Instantiate(clearMonster, transform.position, transform.rotation);
           gameLogic.CrashMonster();
		   Destroy(this.gameObject);
       }
    }
}
