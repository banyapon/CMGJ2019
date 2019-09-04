using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Spring : MonoBehaviour
{
    public AudioSource Punch;
    public GameObject clearMonster;
    public GameLogic gameLogic;
	float startTime;
    int hitting = 0;

    private Vector3 direction;
    private Rigidbody rb;
    private float direction_x = -1.9f;
    private float direction_y = -1.9f;
    private float direction_z = -1f;
    private float SecondsUntilDestroy = 5f;
    private float speed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		startTime = Time.time;
        Respawn();
    }

    public void Respawn()
    {
        // Set ball position in scene
        // transform.position = new Vector3(0, 0.65f, 9.55f);
        //transform.position = new Vector3(1f, 1f, 9f);
        //Set ball velocity to random upwards direction
        direction_x = Random.Range(-1.9f, 1.9f);
        if (direction_x > -1f && direction_x < 1f) {
            speed = 6f;
        }
        direction_y = Random.Range(-1.9f, 1.9f);
        if (direction_y > -1f && direction_y < 1f) {
            speed = 6f;
        }
        direction = new Vector3(direction_x, direction_y, direction_z).normalized;
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(direction_x, direction_y, direction_z);
        // if (Time.time - startTime >= SecondsUntilDestroy) {
		// 	Destroy(this.gameObject);
		// }
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject objectTriggered = collision.gameObject;
        Debug.Log("Hit : " + objectTriggered.tag);

        // https://answers.unity.com/questions/1605453/3d-ball-in-breakout-clone-acts-unpredictably-when.html
        if (objectTriggered.tag == "WallLeft") {
            direction_x *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            if (speed < 7) speed += 1;
            else speed = 7;
            rb.velocity = direction * speed;
        }
        if (objectTriggered.tag == "WallRight") {
            direction_x *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            if (speed < 7) speed += 1;
            else speed = 7;
            rb.velocity = direction * speed;
        }
        if (objectTriggered.tag == "WallBack") {
            direction_z *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            if (speed < 7) speed += 1;
            else speed = 7;
            rb.velocity = direction * speed;
        }
        if (objectTriggered.tag == "Floor") {
            direction_y *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            if (speed < 7) speed += 1;
            else speed = 7;
            rb.velocity = direction * speed;
        }
        if (objectTriggered.tag == "Ceiling") {
            direction_y *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            if (speed < 7) speed += 1;
            else speed = 7;
            rb.velocity = direction * speed;
        }
        if (objectTriggered.tag == "Player") {
            //Instantiate(clearMonster, transform.position, transform.rotation);
            gameLogic.CrashMonster();
            Destroy(this.gameObject);
        }
        if (objectTriggered.tag == "LPunch") {
            Punch.Play();
            direction_x *= -1;
            direction_z *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            rb.velocity = direction * speed;
            if (hitting < 3){
                hitting ++;
            }
            else{
                Instantiate(clearMonster, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        if (objectTriggered.tag == "RPunch") {
            Punch.Play();
            direction_x *= -1;
            direction_z *= -1;
            direction = new Vector3(direction_x, direction_y, direction_z).normalized;
            rb.velocity = direction * speed;
            if (hitting < 3){
                hitting ++;
            }
            else{
                Instantiate(clearMonster, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        /* 
       if(other.gameObject.tag == "RPunch" || other.gameObject.tag == "LPunch"){
           //if(other.gameObject.GetComponent<RightPunch>().inOffTrigger)
           //{
               //gameLogic.GetItems();
                Punch.Play();
                Instantiate(clearMonster, transform.position, transform.rotation);
                Destroy(this.gameObject);
           //}
       }
       */

    }

}
