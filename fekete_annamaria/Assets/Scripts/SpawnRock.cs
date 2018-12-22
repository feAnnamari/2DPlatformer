using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRock : MonoBehaviour {

	[SerializeField] GameObject originalRock;
	Vector3 vector;
	//[SerializeField] GameObject prefabToSpawn;
	//private Transform originalRockTransform;
	//private Vector3 vector;
	//private Transform newTransform;
	// Use this for initialization
	void Start () {
		vector = new Vector3(originalRock.transform.position.x,originalRock.transform.position.y,originalRock.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag=="Player")
		{
			originalRock.transform.position = vector;
		}
	}
}
