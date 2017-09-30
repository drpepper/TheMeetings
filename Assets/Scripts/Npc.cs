using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : Human {

	private float startTime = 0f;
	private int index = 0;
	private NpcConfiguration config;

	// Use this for initialization
	void Awake () {
		config = NpcConfiguration.RAND();
		PickSex();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//float t = (Time.time - startTime) / durationMax;

		if (Time.time > startTime)
		{
			NextIndex ();
			MoveTo(config.list[index]);

			startTime = Time.time + Random.Range (config.minTime, config.maxTime);
		}

		if(!HumanUpdate()) 
		{ 
			NextIndex();
		};
	}

	void NextIndex ()
	{
		index++;
		if (index >= config.list.Count)
		{
			index = 0;		
		}
	}
}
