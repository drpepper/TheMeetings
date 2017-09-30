using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCopier : Human 
{
	private Queue<Direction> _directions = new Queue<Direction> ();
	private Player target = null;
	private Direction _lastRegisterDirection = Direction.Stop;

	public float refreshTime = 0f;
	private float _timeToRefresh = 0f;

	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find ("PlayerOne").GetComponent<Player>();	
		PickSex();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > _timeToRefresh)
		{
			float random = Random.Range (0f, 1f);

			if (random < 0.6f)
			{
				_lastRegisterDirection = target.lastDirection;
				_timeToRefresh = Time.time + Mathf.Min (refreshTime, target.average);
				MoveTo (_lastRegisterDirection);
			}
			else if (random < 0.95f)
			{
				_timeToRefresh = Time.time + refreshTime;				
				MoveTo (_lastRegisterDirection);
			}
			else
			{
				_timeToRefresh = Time.time + refreshTime;				
				MoveTo( (Direction)Random.Range(0,(int)Direction.count));
			}
		}

		HumanUpdate ();
	}
}
