using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float width = 1f;
	public float height = 1f;
	public Vector3 leftBoxCenter;
	public Vector3 rightBoxCenter;

	public GameObject player1;
	public GameObject player2;
	
	void Awake () 
	{
		Vector2 leftPosition = leftBoxCenter + new Vector3(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);
		Vector2 rightPosition = rightBoxCenter + new Vector3(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2), 0);

		bool player1IsLeft = Random.value < 0.5f;

		player1.transform.position = player1IsLeft ? leftPosition : rightPosition;
		player2.transform.position = player1IsLeft ? rightPosition : leftPosition;
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = new Color(1f, 0, 1f, 0.5f);
		Gizmos.DrawCube (leftBoxCenter, new Vector3(width, height, 0));
		Gizmos.DrawCube (rightBoxCenter, new Vector3(width, height, 0));
	}

}
