using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Blood;
    public AudioSource hurt;
    public bool getHurt = false;
    public GameLogic gameLogic;
    // Start is called before the first frame update
    void Start()
    {
        Blood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(getHurt){
            Blood.SetActive(true);
            hurt.Play();
            StartCoroutine(ClearPrefabs());
        }
    }

    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "TMonster"){
            gameLogic.CrashCamera();
            getHurt = true;
        }
    }
    IEnumerator ClearPrefabs(){
			yield return new WaitForSeconds(0.5f);
            getHurt = false;
			Blood.SetActive(false);
	}
}
