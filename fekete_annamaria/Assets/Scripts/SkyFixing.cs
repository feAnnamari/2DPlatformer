using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyFixing : MonoBehaviour {

	[SerializeField] private GameObject cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y,this.transform.position.z);
	}
}
