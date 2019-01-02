using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

  public GameObject _gm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player")
        {
            Debug.Log("ENTERED");  
            _gm.GetComponent<AudioSource>().Play();
            GameManager.Instance.AddPoint(1);
			Destroy(this.gameObject);
        }
	}
}
