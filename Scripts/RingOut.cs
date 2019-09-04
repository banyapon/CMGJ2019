using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOut : MonoBehaviour
{
    public float SecondsUntilDestroy = 1f;
	float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= SecondsUntilDestroy) {
            
			Destroy(this.gameObject);
		}
    }
}
