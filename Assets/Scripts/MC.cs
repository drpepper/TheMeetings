using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC : MonoBehaviour 
{
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerWin;
	public List<GameObject> cops;
	public List<GameObject> npcs;

	void Start() 
	{
		Music.instance.PlayClip(1);
	}
}
