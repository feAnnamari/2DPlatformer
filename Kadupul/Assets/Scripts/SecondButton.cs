using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondButton : MonoBehaviour {

	[SerializeField] private bool death;
	[SerializeField] private GameObject topBouncer;

	[SerializeField] private GameObject botBouncer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!death)
		{
			topBouncer.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Right;
			botBouncer.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Left;
		}
	}
}
