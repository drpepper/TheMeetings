using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player {
	SpriteRenderer spriteRenderer;

	void Start() 
	{
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	void Update () 
	{
		if(freeze) return;

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
			spriteRenderer.color = Color.black;
		else if(Input.GetKeyUp(KeyCode.M))
			spriteRenderer.color = Color.white;

		base.HumanUpdate ();
	}
}
