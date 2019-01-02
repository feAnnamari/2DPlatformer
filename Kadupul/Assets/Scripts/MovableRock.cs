using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableRock : MonoBehaviour {


	[SerializeField] private Vector2 force = new Vector2(100,0);
	private bool played;
	private bool libikokan;
	private bool collided;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		
		if(other.gameObject.tag!="Player"&&!libikokan)
		gameObject.GetComponent<AudioSource>().Play();

		if(other.gameObject.tag == "libikoka" && !played)
		{
			libikokan=true;
			played = true;
			gameObject.tag = "Untagged";
		}
		
	}
}
