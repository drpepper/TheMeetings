using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Human {

	public List<Direction> moves = new List<Direction> {Direction.Left, Direction.Top, Direction.Right, Direction.Down};

	private float startTime = 0f;
	private int index = 0;
	public float durationMax;
	public float durationMin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//float t = (Time.time - startTime) / durationMax;

		if (Time.time > startTime)
		{
			NextIndex ();
			MoveTo(moves[index]);

			startTime = Time.time + Random.Range (durationMin, durationMax);
		}

		if(!HumanUpdate()) 
		{ 
			NextIndex();
		};
	}

	void NextIndex ()
	{
		index++;
		if (index >= moves.Count)
		{
			index = 0;		
		}
	}
}
