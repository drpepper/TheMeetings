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
		const float sampleScale = 10f;
		// Using Time.time as a seed
		float seed = Mathf.Repeat(Time.time, 100f);
		for (int i = 0; i < number; i++)
		{
			// Sample Perlin Noise at random points and take those over a certain value
			while(true)
			{
				float x = Random.value;
				float y = Random.value;

				if(Mathf.PerlinNoise(seed + x * sampleScale, seed + y * sampleScale) > 0.5)
				{
					var localPos = new Vector3 (-width/2 + x * width, -height/2 + y * height, 0f);
					GameObject.Instantiate (pawn, transform.position + localPos, Quaternion.identity);
					break;
				}
			}
		}	
	}
			
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = new Color(1f, 0, 1f, 0.5f);
		Gizmos.DrawCube (transform.position, new Vector3(width, height, 0));
	}
}
