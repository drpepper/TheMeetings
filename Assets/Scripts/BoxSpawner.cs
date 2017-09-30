using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

	public float width = 1f;
	public float height = 1f;
	public int number = 0;
	public GameObject pawn = null;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < number; i++)
		{
			Vector2 position = new Vector2(Random.Range(-width/2, width/2), Random.Range(-height/2, height/2));

			GameObject.Instantiate (pawn, transform.position + new Vector3 (position.x, position.y, 0f), Quaternion.identity);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = new Color(1f, 0, 1f, 0.5f);
		Gizmos.DrawCube (transform.position, new Vector3(width, height, 0));
	}
}
