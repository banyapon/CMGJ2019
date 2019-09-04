using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    Animation animation;
    
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        StartCoroutine(HeadAnimSet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HeadAnimSet(){
			yield return new WaitForSeconds(4f);
			animation.Play("HeadAnim");
	}
}
