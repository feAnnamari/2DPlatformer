using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

	private bool active;
	[SerializeField] private GameObject quitButton;
	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			quitButton.SetActive(active);
			active = !active;
		}
	}
}
