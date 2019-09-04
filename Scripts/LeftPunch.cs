using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPunch : MonoBehaviour
{
    public GameLogic gameLogic;
    public GameObject mon;
    public GameObject direct;
    public bool inOffTrigger = false;
    void Start()
    {
        //direct = Find.GameObject("SphereL");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "LMonster" && !inOffTrigger){
           gameLogic.GetItems();
       }
       else if(other.gameObject.tag == "Monster3"){
           gameLogic.GetItems();
       }
    }

    void OnTriggerStay(Collider other)
    {
       if(other.gameObject.tag == "OffTrigger"){
           inOffTrigger = true;
       }
    }

    void OnTriggerExit(Collider other)
    {
       if(other.gameObject.tag == "OffTrigger"){
           inOffTrigger = false;
           if(gameLogic._SpawnPoint.stageLevel == 5){
                GameObject temp;
                temp = (GameObject)Instantiate(mon, direct.transform.position, direct.transform.rotation);
                //Vector3 pos = temp.transform.position;
                //temp.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
           }
       }
    }
}
