using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour 
{
	private static readonly Vector3 upDirection		= Vector3.up;
	private static readonly Vector3 downDirection 	= Vector3.down;
	private static readonly Vector3 leftDirection 	= Vector3.left;
	private static readonly Vector3 rightDirection 	= Vector3.right;
	private static readonly Vector3 zeroDirection 	= Vector3.zero;

	private static readonly Quaternion	upAngle		= Quaternion.Euler(new Vector3(0f,0f,0f));
	private static readonly Quaternion	downAngle	= Quaternion.Euler(new Vector3(0f,0f,180f));
	private static readonly Quaternion	leftAngle	= Quaternion.Euler(new Vector3(0f,0f,90f));
	private static readonly Quaternion	rightAngle	= Quaternion.Euler(new Vector3(0f,0f,270f));

	private Direction	_directionName	=	Direction.Top;
	private Vector3 	_direction		=	zeroDirection;

	public float		speed			= 	0f;

	// Use this for initialization
	void Start () 
	{
		transform.rotation = upAngle;
	}

	protected bool HumanUpdate () 
	{
		if(_direction == zeroDirection) return true;

		RaycastHit2D[] results = new RaycastHit2D[1];
		int hits = GetComponent<Collider2D>().Raycast(_direction, results, speed * Time.deltaTime);
		if(hits == 0) 
		{
			transform.Translate (upDirection * speed * Time.deltaTime);
			return true;
		} 
		else 
		{
			return false;
		}
	}

	/*void OnCollisionEnter2D(Collision2D coll) 
	{
		Debug.Log("collision");    
    }*/

	public void MoveTo(Direction direction)
	{
		_directionName = direction;

		switch (_directionName)
		{
			case Direction.Stop:
				_direction = zeroDirection;
			break;

		case Direction.Top:
			//_direction = upDirection;
			_direction = upDirection;
			transform.rotation = upAngle;
			break;

		case Direction.Down:
			//_direction = upDirection;
			_direction = downDirection;
			transform.rotation = downAngle;
			break;

		case Direction.Left:
			//_direction = upDirection;
			_direction = leftDirection;
			transform.rotation = leftAngle;
			break;

		case Direction.Right:
			//_direction = upDirection;
			_direction = rightDirection;
			transform.rotation = rightAngle;
			break;
		}
	}
}
