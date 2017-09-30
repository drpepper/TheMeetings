using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human 
{
	public Direction lastDirection = Direction.Stop;

	private int		_inputCount = 0;
	private float	_inputDate	= 0f;
	private float 	_inputTimes = 0f;

	public float average = 0f;

	protected Color firstColor;

	public void RegisterInput ()
	{
		_inputCount++;

		float timeBeforeLastInput = Time.time - _inputDate;

		_inputTimes += timeBeforeLastInput;

		average = _inputTimes / timeBeforeLastInput;

		_inputDate = Time.time;
	}

	// Update is called once per frame

}
