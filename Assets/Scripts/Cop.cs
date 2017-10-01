using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop : MonoBehaviour {
	public float maxSpeed = 3f;
	public float minSpeed = 0.5f;
	public float maxDistance = 5f;
	public float alertPause = 0.5f;

	public GameObject[] players;
	public GameObject alertUI;

	int trackedPlayerIndex = -1;
	float alertTime = -1;

	enum State { WAITING, ALERTED, TRACKING };
	State state = State.WAITING;

	public bool freeze = false;

	
	void Start() 
	{
		MC mc = GameObject.Find ("MC").GetComponent<MC>();
		mc.cops.Add(this.gameObject);

		alertUI = transform.Find("Alert").gameObject;
	}

	void Update () 
	{
		if(freeze) return;


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

			if(playerIndex != -1 && playerDistance < maxDistance && trackedPlayerIndex != playerIndex)
			{
				trackedPlayerIndex = playerIndex;

				state = State.ALERTED;
				alertTime = Time.time;
				alertUI.SetActive(true);

				Music.instance.PlayClip(2);
			}
		}
		
		if(state == State.ALERTED)
		{
			if(Time.time - alertTime > alertPause) 
			{
				state = State.TRACKING;
				alertUI.SetActive(false);

				Music.instance.PlayClip(3);
				Music.instance.PlayOnce(Music.instance.alert);
			}

		}
		else if(state == State.TRACKING)
		{
			Vector3 distanceVector = players[trackedPlayerIndex].transform.position - transform.position;
			float distance = distanceVector.magnitude;

			float speed;
			if(distance > maxDistance) 
			{
				speed = minSpeed;
			}
			else 
			{
				speed = minSpeed + maxSpeed * (1 - (distance / maxDistance));
			}

			transform.position += distanceVector.normalized * speed * Time.deltaTime;
		}
	}
}
