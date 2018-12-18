using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public bool playerHere;
	[SerializeField]  private Animator animator;

	//[SerializeField] private GameObject animateGameObject;

	[SerializeField] private GameObject prefabToSpawn;

	[SerializeField] private GameObject topGround;
	[SerializeField] private GameObject botGround;

	private GameObject otherButton;

	//[SerializeField] private bool death;
	[SerializeField] private bool changeable;

	[SerializeField] private bool death;
	// Use this for initialization
	public int buttonIndex;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHere)
		{
			if(Input.GetButtonDown("Action"))
			{
				if(changeable){
					otherButton = Instantiate(prefabToSpawn,this.transform.position, this.transform.rotation);
				}
				if(animator!=null)
				{
					animator.SetTrigger ("clambersGo");
				}
				if(buttonIndex == 2)
				{
					otherButton.GetComponent<Button>().topGround = this.topGround;
					otherButton.GetComponent<Button>().botGround = this.botGround;
					otherButton.GetComponent<Button>().buttonIndex = this.buttonIndex;
					if(!death)
					{
						topGround.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Right;
						botGround.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Left;
					}
					if(death)
					{
						topGround.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Left;
						botGround.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Right;
					}
					topGround.GetComponent<AudioSource>().Play();
					botGround.GetComponent<AudioSource>().Play();
				}
				{
					Destroy(this.gameObject);
				}

			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player")
		{
			playerHere = true;
		}
	}
	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Player")
		{
			playerHere = false;
		}
	}
}
