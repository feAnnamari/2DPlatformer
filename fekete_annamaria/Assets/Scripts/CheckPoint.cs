using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	float rotationsPerMinute = 10.0f;
	public bool rotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(rotate)
		{
			transform.Rotate(0,6.0f*rotationsPerMinute*Time.deltaTime,0);
		}
	}
}
