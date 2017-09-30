using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour {
	public float maxSpeed = 3f;
	public float maxDistance = 5f;

	public GameObject[] players;
	
	// Update is called once per frame
	void Update () 
	{
		int playerIndex = -1;
		float playerDistance = float.MaxValue;
		for(var i = 0; i < players.Length; i++) 
		{
			float distance = Vector3.Distance(transform.position, players[i].transform.position);
			if(distance < playerDistance) 
			{
				playerIndex = i;
				playerDistance = distance;
			}
		}

		if(playerIndex != -1 && playerDistance < maxDistance)
		{
			Vector3 vector = (players[playerIndex].transform.position - transform.position).normalized;
			float speed = maxSpeed * (1 - (playerDistance / maxDistance));
			transform.position += vector * maxSpeed * Time.deltaTime;
		}
	}
}
