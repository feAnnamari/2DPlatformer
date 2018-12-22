using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour {

	private Vector3 start;
	private Vector3 end;


	private Vector3 addingVect;

	private bool right;

	public enum Positions
	{
		Right, Left
	};

	[SerializeField] private bool alwaysMoving = true;

	public Positions aimPosition;
	[SerializeField] private Positions hidePosition;

	[SerializeField] private float steps;

	[SerializeField] private float distance;

	
	void Start () {
		start = this.transform.position;
		end= new Vector3(this.transform.position.x + distance,start.y, 0);
		if(hidePosition == Positions.Right && !alwaysMoving)
		{
			end= new Vector3(this.transform.position.x - distance,start.y, 0);
		}
		right = true;
		addingVect = new Vector3(steps, 0, 0);
	}
	
	
	void Update () {

		if(alwaysMoving)
		{

			if(this.transform.position.x <= start.x)
			{
				right = true;
			}

			if(this.transform.position.x >= end.x)
			{
				right = false;
			}

			if(right)
			{
				this.transform.position += addingVect;
			}

			if(!right)
			{
				this.transform.position -= addingVect;
			}
		}
		if(!alwaysMoving)
		{
			if(hidePosition == Positions.Left)
			{
				if(aimPosition == Positions.Right && this.transform.position.x <= end.x)
				{
					this.transform.position += addingVect;
				}

				if(aimPosition == Positions.Left && this.transform.position.x >= start.x)
				{
					this.transform.position -= addingVect;
				}	
			}

			if(hidePosition == Positions.Right)
			{
				if(aimPosition == Positions.Right && this.transform.position.x <= start.x)
				{
					this.transform.position += addingVect;
				}

				if(aimPosition == Positions.Left && this.transform.position.x >= end.x)
				{
					this.transform.position -= addingVect;
				}	
			}

		}
	}



	
}
