using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	
	public GameObject[] spawnPoints;

	void Awake () 
	{
		int index1 = Random.Range(0, spawnPoints.Length);
		int index2;
		do 
		{
			index2 = Random.Range(0, spawnPoints.Length);
		} 
		while(index1 == index2);

		player1.transform.position = spawnPoints[index1].transform.position;
		player2.transform.position = spawnPoints[index2].transform.position;

		Debug.Log("player1 spawning at position" + index1);
		Debug.Log("player2 spawning at position" + index2);
	}
	
}
