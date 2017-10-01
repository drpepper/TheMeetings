﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour 
{
	public float distance = 5f;
	public float copDistance = 0.5f;
	public GameObject player1;
	public GameObject player2;
	public GameObject foundIcon;

	public GameObject arrestedScreen;
	public GameObject missedScreen;
	public GameObject foundScreen;

	public float endingTime = 3f;


	MC mc;
	enum State { Playing, Arrested, Missed, Found, Over };
	State state = State.Playing;

	float playingOverTime;

	void Start() 
	{
		mc = GameObject.Find("MC").GetComponent<MC>();
	}
	
	void Update () 
	{
		if(state == State.Playing) 
		{
			UpdatePlay();
		}
		else if(state == State.Arrested) 
		{
			if(Time.time - playingOverTime > endingTime) 
			{
				arrestedScreen.SetActive(true);

				state = State.Over;
			}
		}
		else if(state == State.Missed)
		{
			if(Time.time - playingOverTime > endingTime) 
			{
				missedScreen.SetActive(true);

				state = State.Over;
			}
		}
		else if(state == State.Found)
		{
			if(Time.time - playingOverTime > endingTime) 
			{
				foundScreen.SetActive(true);

				state = State.Over;
			}
		}
	}		


	void UpdatePlay()
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			if(Vector3.Distance(player1.transform.position, player2.transform.position) < distance) 
			{
				// put the players at the same position
				player1.transform.position = new Vector3(player1.transform.position.x, player2.transform.position.y, player1.transform.position.z); 
				
				// Show the found icon
				foundIcon.SetActive(true);
				foundIcon.transform.position = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);

				FreezeAll();
				Music.instance.PlayOnce(Music.instance.win);
				Music.instance.PlayFirstClip();

				endingTime = Time.time;
				state = State.Found;
			}
			else 
			{
				//loseScreen.SetActive(true);
				FreezeAll();
				Music.instance.PlayOnce(Music.instance.lose);
				Music.instance.PlayFirstClip();

				endingTime = Time.time;
				state = State.Missed;
			}
		}
		else 
		{
			foreach(var cop in mc.cops) 
			{
				if(Vector3.Distance(cop.transform.position, player1.transform.position) < copDistance)
				{
					player1.transform.Find("Caught").gameObject.SetActive(true);
					FreezeAll();
					Music.instance.PlayOnce(Music.instance.lose);
					Music.instance.PlayFirstClip();

					endingTime = Time.time;
					state = State.Arrested;

					break;
				}
				else if(Vector3.Distance(cop.transform.position, player2.transform.position) < copDistance) 
				{
					player2.transform.Find("Caught").gameObject.SetActive(true);
					FreezeAll();
					Music.instance.PlayOnce(Music.instance.lose);
					Music.instance.PlayFirstClip();

					endingTime = Time.time;
					state = State.Arrested;

					break;
				}
			}
		}
	}

	void FreezeAll() 
	{
		mc.playerOne.GetComponent<Player>().freeze = true;
		mc.playerTwo.GetComponent<Player>().freeze = true;
		foreach(var cop in mc.cops) 
		{
			if(cop.GetComponent<Cop>()) cop.GetComponent<Cop>().freeze = true;
			else cop.GetComponent<UndercoverCop>().freeze = true;
		} 
		foreach(var npc in mc.npcs) 
		{
			if(npc.GetComponent<Npc>()) npc.GetComponent<Npc>().freeze = true;
			else npc.GetComponent<NpcCopier>().freeze = true;
		} 
	}
}
