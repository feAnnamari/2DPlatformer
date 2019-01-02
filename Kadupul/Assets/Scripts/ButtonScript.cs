using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	public bool playerHere;
	[SerializeField]  private Animator animator;

	//[SerializeField] private GameObject animateGameObject;

	[SerializeField] private GameObject prefabToSpawn;

	[SerializeField] private List<GameObject> leftHideGround = new List<GameObject>();
	[SerializeField] private List<GameObject> rightHideGround = new List<GameObject>();

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
					animator.SetTrigger ("Go");
				}
				if(buttonIndex == 2)
				{
					otherButton.GetComponent<ButtonScript>().leftHideGround = this.leftHideGround;
					otherButton.GetComponent<ButtonScript>().rightHideGround = this.rightHideGround;
					otherButton.GetComponent<ButtonScript>().buttonIndex = this.buttonIndex;
					if(!death)
					{
						foreach (var item in leftHideGround)
						{
							item.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Right;
							item.GetComponent<AudioSource>().Play();
						}
						foreach (var item in rightHideGround)
						{
							item.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Left;
							item.GetComponent<AudioSource>().Play();
						}
					}
					if(death) //hiding
					{
						foreach (var item in leftHideGround)
						{
							item.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Left;
							item.GetComponent<AudioSource>().Play();
						}
						foreach (var item in rightHideGround)
						{
							item.GetComponent<MovingTile>().aimPosition = MovingTile.Positions.Right;
							item.GetComponent<AudioSource>().Play();
						}
					}
				}
				{
					Destroy(this.gameObject);
				}

			}
		}
	}

	private void OnCollisionStay2D(Collision2D other) {
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
