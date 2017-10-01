using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndercoverCop : MonoBehaviour {
	public float maxSpeed = 3f;
	public float minSpeed = 0.5f;
	public float maxDistance = 5f;
	public float alertPause = 0.5f;
	public float gracePeriod = 5f;

	public Color revealedColor = Color.black;
	public Color undercoverColor = Color.white;
	public float undercoverTime = 5f;

	public Sprite undercoverImage;
	public Sprite revealedImage;

	GameObject alertUI;

	SpriteRenderer spriteRenderer;

	int trackedPlayerIndex = -1;
	float alertTime = -1;

	enum State { SLEEPING, WAITING, ALERTED, TRACKING };
	State state = State.SLEEPING;

	GameObject[] players;

	float startTime = -1f;
	float firstAlertTime = -1;

	void Start() 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		players = new GameObject[]{ GameObject.Find ("PlayerOne"), GameObject.Find ("PlayerTwo") };

		startTime = Time.time;

		MC mc = GameObject.Find ("MC").GetComponent<MC>();
		mc.cops.Add(this.gameObject);
		
		alertUI = transform.Find("Alert").gameObject;
	}

	// Update is called once per frame
	void Update () 
	{
		if(state == State.SLEEPING)
		{
			if(Time.time - startTime > gracePeriod) state = State.WAITING;
		}
		else if(state == State.ALERTED)
		{
			if(Time.time - alertTime > alertPause) 
			{
				state = State.TRACKING;
				alertUI.SetActive(false);
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

		if(state == State.WAITING || state == State.TRACKING)
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

				if(firstAlertTime == -1) firstAlertTime = Time.time;
			}
		}

		if(firstAlertTime != -1) 
		{
			bool isUndercover = Mathf.Repeat(Time.time - firstAlertTime, undercoverTime * 2) >= undercoverTime;
			spriteRenderer.sprite = isUndercover ? undercoverImage : revealedImage;
		}
	}
}
