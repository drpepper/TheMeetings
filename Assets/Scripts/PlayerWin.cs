using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour 
{
	public float distance = 5f;
	public GameObject player1;
	public GameObject player2;
	public GameObject screen;
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(player1.transform.position, player2.transform.position) < distance) 
		{
			screen.SetActive(true);
		}
	}
}
