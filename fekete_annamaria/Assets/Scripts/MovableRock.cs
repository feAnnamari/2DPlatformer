using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableRock : MonoBehaviour {


	[SerializeField] private Vector2 force = new Vector2(100,0);
	private bool played;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		
		if(other.gameObject.tag == "libikoka" && !played)
		{
			gameObject.GetComponent<AudioSource>().Play();
			played = true;
			gameObject.tag = "Untagged";
		}
		
	}
}
