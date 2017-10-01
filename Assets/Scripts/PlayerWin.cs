using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
	public string currentSceneName = "";
	public string nextSceneName = "";


	MC mc;
	enum State { Playing, Arrested, Missed, Found, Over };
	State state = State.Playing;

	float playingOverTime;
	bool didWin = false;

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

				didWin = true;
				state = State.Over;
			}
		}
		else if(state == State.Over)
		{
			if(Input.anyKeyDown)
			{
				SceneManager.LoadScene(didWin ? nextSceneName : currentSceneName);
			}
		}
	}		


	void UpdatePlay()
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			if(Vector3.Distance(player1.transform.position, player2.transform.position) < distance) 
			{
				// Position the players next to each other
				Vector3 centerPos = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
				player1.transform.position = centerPos + new Vector3(-0.25f, 0, 0);
				player2.transform.position = centerPos + new Vector3(0.25f, 0, 0);

				// Show the found icon
				foundIcon.SetActive(true);
				foundIcon.transform.position = centerPos;

				FreezeAll();
				Music.instance.PlayOnce(Music.instance.win);
				Music.instance.PlayFirstClip();

				playingOverTime = Time.time;
				state = State.Found;
			}
			else 
			{
				player1.transform.Find("Caught").gameObject.SetActive(true);
				player2.transform.Find("Caught").gameObject.SetActive(true);

				FreezeAll();
				Music.instance.PlayOnce(Music.instance.lose);
				Music.instance.PlayFirstClip();

				playingOverTime = Time.time;
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

					playingOverTime = Time.time;
					state = State.Arrested;

					break;
				}
				else if(Vector3.Distance(cop.transform.position, player2.transform.position) < copDistance) 
				{
					player2.transform.Find("Caught").gameObject.SetActive(true);
					FreezeAll();
					Music.instance.PlayOnce(Music.instance.lose);
					Music.instance.PlayFirstClip();

					playingOverTime = Time.time;
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
