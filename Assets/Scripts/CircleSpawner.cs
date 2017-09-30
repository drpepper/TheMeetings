using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour {

	public float radius = 0f;
	public int number = 0;
	public GameObject pawn = null;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < number; i++)
		{
			Vector2 position = Random.insideUnitCircle * radius;

			GameObject.Instantiate (pawn, transform.position + new Vector3 (position.x, position.y, 0f), Quaternion.identity);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnDrawGizmos ()
	{
		Gizmos.color = new Color(1f, 0, 1f, 0.5f);
		Gizmos.DrawSphere (transform.position, radius);
	}
}
