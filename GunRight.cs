using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRight : MonoBehaviour
{
    public float fireRate = 0.4f;
	private float nextFire = 0.0f;
    public GameObject bullet,gun,muzzles;
    public int stock = 20;
    public bool isReload = true;
    Animator anim;

    void Start(){
        muzzles.SetActive(false);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isReload){
            if(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && Time.time > nextFire){
                nextFire = Time.time + fireRate;
                Fire();
            }
        }else{
            if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && Time.time > nextFire){
                StartCoroutine(ReLoaded(1f));
            }
        }
        if(stock <= 0){
            stock  = 0;
            isReload = false;
            anim.SetBool("AmmoOut",true);
        }
    }

    IEnumerator ReLoaded(float waitTime){
        yield return new WaitForSeconds(waitTime);
        stock = 20;
        isReload = true;
        anim.SetBool("AmmoOut",false);
    }

    public void Fire(){
        muzzles.SetActive(true);
        stock = stock - 1;
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine(HideMuzzle(0.2f));
    }

    private IEnumerator HideMuzzle(float waitTime){
        yield return new WaitForSeconds(waitTime);
        muzzles.SetActive(false);
    }
}
