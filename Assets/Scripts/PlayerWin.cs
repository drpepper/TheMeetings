using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour 
{
	public float distance = 5f;
	public float copDistance = 0.5f;
	public GameObject player1;
	public GameObject player2;
	public GameObject winScreen;
	public GameObject loseScreen;
	public GameObject foundIcon;

	MC mc;
	bool gameOver = false;

	void Start() 
	{
		mc = GameObject.Find("MC").GetComponent<MC>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gameOver) return;


		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			if(Vector3.Distance(player1.transform.position, player2.transform.position) < distance) 
			{
				// put the players at the same position
				player1.transform.position = new Vector3(player1.transform.position.x, player2.transform.position.y, player1.transform.position.z); 
				
				// Show the found icon
				foundIcon.SetActive(true);
				foundIcon.transform.position = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);

				//winScreen.SetActive(true);
				gameOver = true;
			}
			else 
			{
				//loseScreen.SetActive(true);
				gameOver = true;
			}
		}
		else 
		{
			foreach(var cop in mc.cops) 
			{
				if(Vector3.Distance(cop.transform.position, player1.transform.position) < copDistance)
				{
					player1.transform.Find("Caught").gameObject.SetActive(true);
					gameOver = true;
					//loseScreen.SetActive(true);
					break;
				}
				else if(Vector3.Distance(cop.transform.position, player2.transform.position) < copDistance) 
				{
					player2.transform.Find("Caught").gameObject.SetActive(true);
					gameOver = true;
					//loseScreen.SetActive(true);			
					break;
				}
			}
		}
	}
}
