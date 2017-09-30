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
		new NpcConfiguration(2f,  4f, Direction.Left, Direction.Right, Direction.Top, Direction.Down),
		new NpcConfiguration(0.1f, 0.2f, Direction.Stop),
		new NpcConfiguration(0.01f, 0.1f, Direction.Left, Direction.Right),
		new NpcConfiguration(0.5f, 1f, Direction.Top, Direction.Down, Direction.Top, Direction.Down, Direction.Top, Direction.Down, Direction.Stop),

	};

	public static NpcConfiguration RAND ()
	{
		return ALL [Random.Range (0, ALL.Count)];
	}
}