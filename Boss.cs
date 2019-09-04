using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{
    public GameLogic gameLogic;
    public int hp = 20;
    // Start is called before the first frame update
    void Start()
    {
        hp = Random.Range(20,50);
    }

    // Update is called once per frame
    void Update()
    {
        if(hp < 1){
            hp = 0;
            StartCoroutine(ChangeScene());
        }
    }

    void OnTriggerExit(Collider other)
    {
       if(other.gameObject.tag == "Bullet"){
          
           if(gameLogic._SpawnPoint.stageLevel == 5){
              hp = hp - 1;
           }
       }
    }

    public IEnumerator ChangeScene(){
			yield return new WaitForSeconds(0.1f);
			SceneManager.LoadScene("Win", LoadSceneMode.Single);
	}
}
