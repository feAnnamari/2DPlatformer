using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour {

	[SerializeField] GameObject mainCam;

	[SerializeField] GameObject mainCanvas;

	[SerializeField] GameObject endCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player")
		{
			GetComponent<AudioSource>().Play();
			mainCam.GetComponent<AudioSource>().Stop();
			mainCanvas.SetActive(false);
			endCanvas.SetActive(true);
			other.gameObject.SetActive(false);
		}
	}
}
