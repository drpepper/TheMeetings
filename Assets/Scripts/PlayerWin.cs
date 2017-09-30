using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour 
{
	public float distance = 5f;
	public float copDistance = 0.5f;
	public GameObject player1;
	public GameObject player2;
	public GameObject cop;
	public GameObject winScreen;
	public GameObject loseScreen;

	bool gameOver = false;
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOver) return;

		
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			if(Vector3.Distance(player1.transform.position, player2.transform.position) < distance) 
			{
				winScreen.SetActive(true);
				gameOver = true;
			}
			else 
			{
				loseScreen.SetActive(true);
				gameOver = true;
			}
		}
		else if(Vector3.Distance(cop.transform.position, player1.transform.position) < copDistance || 
			Vector3.Distance(cop.transform.position, player2.transform.position) < copDistance) 
		{
			loseScreen.SetActive(true);			
			gameOver = true;
		}
	}
}
