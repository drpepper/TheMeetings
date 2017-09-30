using System.Collections.Generic;
using UnityEngine;

public class NpcConfiguration 
{
	public List<Direction>	list		= null;
	public float			minTime		= 0f;
	public float			maxTime		= 0f;

	public NpcConfiguration(float min, float max, params Direction[] directions)
	{
		list	= new List<Direction> (directions);
		minTime = min;
		maxTime = max;
	}

	public static readonly List<NpcConfiguration> ALL = new List<NpcConfiguration> () 
	{
		new NpcConfiguration(0.1f, 0.5f, Direction.Stop, Direction.Left, Direction.Right, Direction.Left, Direction.Right),
		new NpcConfiguration(0.5f, 1f, Direction.Stop, Direction.Left, Direction.Stop, Direction.Left, Direction.Down, Direction.Down, Direction.Stop, Direction.Right, Direction.Right, Direction.Stop),
		new NpcConfiguration(0.3f,  0.6f, Direction.Left, Direction.Right),
		new NpcConfiguration(0.3f,  0.6f, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Stop),
		new NpcConfiguration(0.3f,  0.6f, Direction.Left, Direction.Right, Direction.Stop, Direction.Right, Direction.Left, Direction.Stop),
		new NpcConfiguration(0.1f, 0.2f, Direction.Stop),
		new NpcConfiguration(0.2f, 0.6f, Direction.Stop, Direction.Stop, Direction.Stop, Direction.Stop, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Top, Direction.Down, Direction.Left, Direction.Right),
		new NpcConfiguration(0.1f, 0.2f, Direction.Stop),
		new NpcConfiguration(0.5f, 1f, Direction.Top, Direction.Down, Direction.Top, Direction.Down, Direction.Top, Direction.Down, Direction.Stop),
		new NpcConfiguration(1f, 2f, Direction.Top, Direction.Right, Direction.Down, Direction.Left, Direction.Right, Direction.Left, Direction.Right, Direction.Left, Direction.Left, Direction.Top, Direction.Stop, Direction.Top, Direction.Down),
		new NpcConfiguration(10f, 15f, Direction.Stop, Direction.Left, Direction.Right, Direction.Stop),
		new NpcConfiguration(5f, 20f, Direction.Stop, Direction.Top, Direction.Down),
		new NpcConfiguration(0.1f, 0.2f, Direction.Stop),
		new NpcConfiguration(0.8f, 1.2f, Direction.Left, Direction.Right),
		new NpcConfiguration(0.8f, 1.2f, Direction.Top, Direction.Down),
		new NpcConfiguration(0.3f, 0.9f, Direction.Left, Direction.Down, Direction.Right, Direction.Top),
		new NpcConfiguration(0.1f, 0.2f, Direction.Stop),
		new NpcConfiguration(0.5f, 1f, Direction.Left, Direction.Top),
		new NpcConfiguration(0.9f, 2.5f, Direction.Top, Direction.Right),
		new NpcConfiguration(0.3f, 0.9f, Direction.Down, Direction.Left),
		new NpcConfiguration(1f, 3f, Direction.Stop, Direction.Stop, Direction.Left, Direction.Right),
	};

	public static NpcConfiguration RAND ()
	{
		return ALL [Random.Range (0, ALL.Count)];
	}
}