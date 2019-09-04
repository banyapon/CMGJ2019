using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPrefab : MonoBehaviour
{
    public GameObject[] leftMon;
	public GameObject[] rightMon;
    public GameObject topMon;
    public GameObject mon3;
    public GameObject monS;

    public int stageLevel = 1;
	bool ItemPowerup = false;
    bool canSpawn = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(canSpawn && stageLevel == 1)
        {
            canSpawn = false;
            if(ItemPowerup)
            {
                int randomZ = Random.Range(0, 4);
                if(randomZ < 2){
                    StartCoroutine(spawnMonLevel1Type4());
                }
                else{
                    StartCoroutine(spawnMonLevel1Type2());
                }
            }
            else
            {
                StartCoroutine(spawnMonLevel1Type1());
            }
        }
        else if(canSpawn && stageLevel == 2)
        {
            canSpawn = false;
            if(ItemPowerup)
            {
                int randomZ = Random.Range(0, 3);
                if (randomZ != 0){
                    StartCoroutine(setSpawnMonT2());
                }
                else{
                    StartCoroutine(spawnMonLevel1Type3());
                }
            }
            else
            {
                StartCoroutine(setSpawnMonT());
            }
        }
        else if(canSpawn && stageLevel == 3)
        {
            canSpawn = false;
            if(ItemPowerup)
            {
                StartCoroutine(setSpawnMon3());
            }
            else
            {
                StartCoroutine(setSpawnMon3mid());
            }
        }
        else if(canSpawn && stageLevel == 4)
        {
            canSpawn = false;
            if(ItemPowerup)
            {
                StartCoroutine(setSpawnMonS());
            }
            else
            {
                StartCoroutine(setSpawnMonT());
            }
        }
	}

    void spawnMonL()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(leftMon[0]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(-0.1f, 1.5f, pos.z);
    }

    void spawnMonLdown()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(leftMon[0]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(-0.1f, 0.75f, pos.z);
    }

    void spawnMonLside()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(leftMon[1]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.5f, 1.25f, pos.z);
    }

    void spawnMonLup()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(leftMon[2]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.3f, 1.5f, pos.z);
    }

    void spawnMonLup2()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(leftMon[2]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.8f, 1.5f, pos.z);
    }

    void spawnMonR()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(rightMon[0]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.5f, 1.5f, pos.z);
    }

    void spawnMonRdown()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(rightMon[0]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.5f, 0.75f, pos.z);
    }

    void spawnMonRside()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(rightMon[1]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(-0.1f, 1.25f, pos.z);
    }

    void spawnMonRup()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(rightMon[2]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.3f, 1.5f, pos.z);
    }

    void spawnMonRup2()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(rightMon[2]);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(-0.3f, 1.5f, pos.z);
    }

    void spawnMonTop()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(topMon);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.3f, 1.5f, pos.z);
    }

    void spawnMon3mid()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(mon3);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(-0.4f, 1f, pos.z);
        
        temp = (GameObject)Instantiate(mon3);
        pos = temp.transform.position;
        temp.transform.position = new Vector3(1f, 1f, pos.z);
    }

    void spawnMon3random()
    {
        int randomX = Random.Range(0, 3);

        if(randomX != 0){
            GameObject temp;
            temp = (GameObject)Instantiate(mon3);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(-0.2f, 0.4f, pos.z);
        }
        else{
            GameObject temp;
            temp = (GameObject)Instantiate(mon3);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(-0.2f, 1.5f, pos.z);
        }

        randomX = Random.Range(0, 3);
        if(randomX == 0){
            GameObject temp;
            temp = (GameObject)Instantiate(mon3);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(0.8f, 0.4f, pos.z);
        }
        else{
            GameObject temp;
            temp = (GameObject)Instantiate(mon3);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(0.8f, 1.5f, pos.z);
        }
    }

    void spawnMonSpring()
    {
        GameObject temp;
        temp = (GameObject)Instantiate(monS);
        Vector3 pos = temp.transform.position;
        temp.transform.position = new Vector3(0.3f, 1.5f, pos.z);
    }

    IEnumerator spawnMonLevel1Type1()
    {
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonR();
        yield return new WaitForSeconds(0.5f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonR();
        yield return new WaitForSeconds(0.5f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonR();
        yield return new WaitForSeconds(0.5f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonR();
        yield return new WaitForSeconds(0.5f);
        spawnMonL();
        yield return new WaitForSeconds(0.25f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator spawnMonLevel1Type2()
    {
        spawnMonLside();
        yield return new WaitForSeconds(0.5f);
        spawnMonRside();
        yield return new WaitForSeconds(0.5f);
        spawnMonLup2();
        yield return new WaitForSeconds(1f);
        spawnMonRside();
        yield return new WaitForSeconds(0.5f);
        spawnMonLside();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup2();

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator spawnMonLevel1Type3()
    {
        spawnMonLup();
        yield return new WaitForSeconds(0.5f);
        spawnMonLup();
        yield return new WaitForSeconds(0.5f);
        spawnMonLup();
        yield return new WaitForSeconds(0.5f);
        spawnMonLup();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator spawnMonLevel1Type4()
    {
        spawnMonL();
        yield return new WaitForSeconds(0.25f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();
        yield return new WaitForSeconds(1f);
        spawnMonL();
        yield return new WaitForSeconds(0.25f);
        spawnMonL();
        yield return new WaitForSeconds(0.5f);
        spawnMonRup();

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator setSpawnMonT()
    {
        int randomT = Random.Range(0, 3);
        if(randomT == 1){
            spawnMonTop();
            yield return new WaitForSeconds(0.05f);
            spawnMonLdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonRdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonLdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonRdown();
        }
        else if(randomT == 2){
            spawnMonTop();
            yield return new WaitForSeconds(0.05f);
            spawnMonRdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonLdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonRdown();
            yield return new WaitForSeconds(0.25f);
            spawnMonLdown();
        }

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator setSpawnMonT2()
    {
        spawnMonTop();

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator setSpawnMon3()
    {
        spawnMon3mid();
        yield return new WaitForSeconds(3f);
        spawnMon3random();
        yield return new WaitForSeconds(2.5f);
        spawnMon3random();
        yield return new WaitForSeconds(2f);

        spawnMon3mid();
        yield return new WaitForSeconds(1.5f);
        spawnMon3random();
        yield return new WaitForSeconds(1f);
        spawnMon3mid();
        yield return new WaitForSeconds(0.5f);
        
        spawnMon3random();
        yield return new WaitForSeconds(0.5f);
        spawnMon3random();
        yield return new WaitForSeconds(0.5f);
        spawnMon3random();
        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(2.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator setSpawnMon3mid()
    {
        spawnMon3mid();

        yield return new WaitForSeconds(1.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }

    IEnumerator setSpawnMonS()
    {
        spawnMonSpring();
        yield return new WaitForSeconds(3.0f);
        spawnMonSpring();
        yield return new WaitForSeconds(3.0f);
        ItemPowerup = !ItemPowerup;
        canSpawn = true;
    }
}
