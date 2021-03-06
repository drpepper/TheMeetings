﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float width = 1f;
	public float height = 1f;
	public float minSeparationDistance = 1f;

	public GameObject player1;
	public GameObject player2;
	
	void Start () 
	{
		player1.transform.position = transform.position + new Vector3(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);
		do 
		{
			player2.transform.position = transform.position + new Vector3(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);
		}
		while(Vector3.Distance(player1.transform.position, player2.transform.position) < minSeparationDistance);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = new Color(1f, 0, 1f, 0.5f);
		Gizmos.DrawCube (transform.position, new Vector3(width, height, 0));
	}

}
