using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player {

	void Awake () 
	{
		PickSex();
		firstColor = spriteRenderer.color;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.S) == true)
		{
			MoveTo (Direction.Down);
			lastDirection = Direction.Down;
		}
		else if (Input.GetKeyDown (KeyCode.Z) == true || Input.GetKeyDown(KeyCode.W))
		{
			MoveTo (Direction.Top);
			lastDirection = Direction.Top;
		}
		else if (Input.GetKeyDown (KeyCode.Q) == true || Input.GetKeyDown(KeyCode.A))
		{
			MoveTo (Direction.Left);
			lastDirection = Direction.Left;
		}
		else if (Input.GetKeyDown (KeyCode.D) == true)
		{
			MoveTo (Direction.Right);
			lastDirection = Direction.Right;
		}
		else if (Input.GetKey (KeyCode.Q)	== false &&
			Input.GetKey (KeyCode.D)		== false &&
			Input.GetKey (KeyCode.S)		== false &&
			Input.GetKey (KeyCode.Z)		== false &&
			Input.GetKey (KeyCode.W)		== false &&
			Input.GetKey(KeyCode.A) 		== false)
		{
			MoveTo (Direction.Stop);
			lastDirection = Direction.Stop;
		}

		if (Input.GetKeyDown (KeyCode.X))
			spriteRenderer.color = Color.yellow;
		else if(Input.GetKeyUp(KeyCode.X))
			spriteRenderer.color = firstColor;

		base.HumanUpdate ();
	}
}
