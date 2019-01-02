using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChange : MonoBehaviour {

	[SerializeField] private GameObject cam1, cam2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player")
		{
			Debug.Log("Playerentered");
			cam1.SetActive(false);
			cam2.SetActive(true);
		}

	}
}
