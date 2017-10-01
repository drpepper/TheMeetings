using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour 
{
	public static Music instance = null;

	public AudioClip loop1 = null;
	public AudioClip loop2 = null;
	public AudioClip loop3 = null;
	public AudioClip alert = null;
	public AudioClip win = null;
	public AudioClip lose = null;

	public AudioSource sourceA = null;
	public AudioSource sourceB = null;

	private AudioSource sourceToFadeIn = null;
	private AudioSource sourceToFadeOut = null;
	private AudioSource currentSource = null;

	public float fadeInTime = 0f;
	public float fadeOutTime = 0f;

	private float fadeInStart = 0f;
	private float fadeOutStart = 0f;
	private int currentIndex = -1;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			GameObject.Destroy (instance.gameObject);
		}
	
	}

	public void PlayClip(int index) 
	{
		if(index <= currentIndex) return;

		currentIndex = index;
		switch(currentIndex) 
		{
			case 1: PlayClip(loop1); break;
			case 2: PlayClip(loop2); break;
			case 3: PlayClip(loop3); break;
		}
	}

	public void PlayFirstClip() 
	{
		currentIndex = -1;
		PlayClip(1);
	}

	private void PlayClip(AudioClip clip)
	{
		if (currentSource == null)
		{
			currentSource = sourceA;
			sourceToFadeIn = sourceA;
			currentSource.volume = 0f;
			currentSource.clip = clip;
			currentSource.Play ();
			fadeInStart = Time.time;
		}
		else if (currentSource == sourceA)
		{
			currentSource = sourceB;
			sourceB.clip = clip;
			sourceToFadeIn = sourceB;
			sourceToFadeOut = sourceA;
			fadeInStart = Time.time;
			fadeOutStart = Time.time;

			currentSource.volume = 0f;
			currentSource.Play ();
		}
		else
		{
			currentSource = sourceA;
			currentSource.clip = clip;
			sourceToFadeIn = sourceA;
			sourceToFadeOut = sourceB;

			currentSource.volume = 0f;
			currentSource.Play ();
		}
	}

	public void PlayOnce(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint (clip, Vector3.zero, 1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if (Input.GetKeyDown (KeyCode.A))
		{
			instance.PlayClip (instance.loop1);
		}
		if (Input.GetKeyDown (KeyCode.Z))
		{
			instance.PlayClip (instance.loop2);
		}
		if (Input.GetKeyDown (KeyCode.E))
		{
			instance.PlayClip(instance.loop3);
		}
		*/

		if (sourceToFadeIn != null)
		{
			FadeIn ();
		}

		if (sourceToFadeOut != null)
		{
			FadeOut ();
		}
	}

	void FadeIn ()
	{
		float t = (Time.time - fadeInStart) / fadeInTime;
		sourceToFadeIn.volume = Mathf.Lerp (0f, 1f, t);

		if (t >= 1f)
		{
			sourceToFadeIn.volume = 1f;
			sourceToFadeIn = null;
		}
	}

	void FadeOut ()
	{
		float t = (Time.time - fadeOutStart) / fadeOutTime;
		sourceToFadeOut.volume = Mathf.Lerp (1f, 0f, t);

		if (t >= 1f)
		{
			sourceToFadeOut.volume = 0f;
			sourceToFadeOut.Stop ();
			sourceToFadeOut = null;
		}
	}
}
