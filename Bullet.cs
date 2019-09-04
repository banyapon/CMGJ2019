using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float Speed = 0.7f;
	float SecondsUntilDestroy = 1.2f;
	float startTime;
 
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	void FixedUpdate(){
		this.gameObject.transform.position += Speed * this.gameObject.transform.forward;
		if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy(this.gameObject);
		}
	}
 
	void OnTriggerEnter(Collider collision){
		if(collision.gameObject.tag == "Enemy"){
			Destroy(this.gameObject);
		}
	}
}
