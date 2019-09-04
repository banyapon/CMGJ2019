using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketBullet : MonoBehaviour
{
    float Speed = 0.01f;
	float SecondsUntilDestroy = 3f;
    float startTime;
    void Start()
    {
        float startTime;
    }

    void Update()
    {
        this.gameObject.transform.position += Speed * this.gameObject.transform.forward;
		if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy(this.gameObject);
		}
    }
}
