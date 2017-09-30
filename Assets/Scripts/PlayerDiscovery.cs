using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiscovery : MonoBehaviour 
{
	public int count = 3;

	private List<Player> players = new List<Player> ();

	private bool hightLightActivated = false;

	// Use this for initialization
	void Start () 
	{
		players.Add (GameObject.Find ("PlayerOne").GetComponent<Player> ());
		players.Add (GameObject.Find ("PlayerTwo").GetComponent<Player> ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		//POWER
		if (Input.GetKeyDown (KeyCode.P) && hightLightActivated == false && count > 0)
		{
			count--;
			hightLightActivated = true;
			StartCoroutine (Highlight (players[0]));
		}
	}

	IEnumerator Highlight(Player player)
	{
		player.SetColor(Color.red);
		yield return new WaitForSeconds (1f);
		player.SetColor(Color.white);
		hightLightActivated = false;
	}
}
