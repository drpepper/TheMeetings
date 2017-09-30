using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player {

	void Awake () 
	{
		PickSex();
		firstColor = spriteRenderer.color;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.DownArrow) == true)
		{
			MoveTo (Direction.Down);
			lastDirection = Direction.Down;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) == true)
		{
			MoveTo (Direction.Top);
			lastDirection = Direction.Top;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow) == true)
		{
			MoveTo (Direction.Left);
			lastDirection = Direction.Left;
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow) == true)
		{
			MoveTo (Direction.Right);
			lastDirection = Direction.Right;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)	== false &&
			Input.GetKey (KeyCode.RightArrow)	== false &&
			Input.GetKey (KeyCode.DownArrow)	== false &&
			Input.GetKey (KeyCode.UpArrow)		== false)
		{
			MoveTo (Direction.Stop);
			lastDirection = Direction.Stop;
		}

		if (Input.GetKeyDown (KeyCode.M))
			spriteRenderer.color = Color.yellow;
		else if(Input.GetKeyUp(KeyCode.M))
			spriteRenderer.color = firstColor;

		base.HumanUpdate ();
	}
}
