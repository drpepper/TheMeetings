using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human 
{

	// Use this for initialization
	void Start () 
	{
		Debug.Log("player starting");
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.DownArrow) == true)
		{
			MoveTo (Direction.Down);
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow) == true)
		{
			MoveTo (Direction.Top);
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow) == true)
		{
			MoveTo (Direction.Left);
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow) == true)
		{
			MoveTo (Direction.Right);
		}
		else if (Input.GetKey (KeyCode.LeftArrow)	== false &&
		         Input.GetKey (KeyCode.RightArrow)	== false &&
		         Input.GetKey (KeyCode.DownArrow)	== false &&
		         Input.GetKey (KeyCode.UpArrow)		== false)
		{
			MoveTo (Direction.Stop);
		}

		base.HumanUpdate ();
	}
}
