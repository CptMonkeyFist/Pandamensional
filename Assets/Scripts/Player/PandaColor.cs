﻿using UnityEngine;
using System.Collections;
using System;

public class PandaColor : MonoBehaviour {
	public bool IsBlueUnlocked;
	public bool IsRedUnlocked;
	public bool IsYellowUnlocked;

	public eColor currentColor;

	//TODO: Put in public LevelColor here

	// Use this for initialization
	void Start () {
		currentColor = eColor.White;
		IsBlueUnlocked = false;
		IsYellowUnlocked = false;
		IsRedUnlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("BlueShift") &&
		    IsBlueUnlocked)
		{
			ColorShift (eColor.Blue);
		}

		if (Input.GetButtonDown("RedShift") &&
		    IsRedUnlocked)
		{
			ColorShift (eColor.Red);
		}

		if (Input.GetButtonDown("YellowShift") &&
		    IsYellowUnlocked)
		{
			ColorShift (eColor.Yellow);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		string tag = other.gameObject.tag;
		if (tag.Equals("RedTrigger"))
		{
			UnlockColor (eColor.Red);
		}
		if (tag.Equals("BlueTrigger"))
		{
			UnlockColor (eColor.Blue);
		}
		if (tag.Equals("YellowTrigger"))
		{
			UnlockColor (eColor.Yellow);
		}

		other.gameObject.SetActive(false);
	}

	public void UnlockColor(eColor newColor)
	{
		switch (newColor)
		{
		case eColor.Blue:
			if (IsBlueUnlocked)
				Debug.Log("Unlocked blue when it was already unlocked");
			else
				IsBlueUnlocked = true;
			break;
		case eColor.Red:
			if (IsRedUnlocked)
				Debug.Log("Unlocked blue when it was already unlocked");
			else
				IsRedUnlocked = true;
			break;
		case eColor.Yellow:
			if (IsYellowUnlocked)
				Debug.Log("Unlocked blue when it was already unlocked");
			else
				IsYellowUnlocked = true;
			break;
		default:
			throw new Exception("Color " + newColor.ToString() + " is invalid");
		}
		
		ColorShift(newColor);
	}

	public void ColorShift(eColor newColor)
	{
		if (currentColor == newColor)
			return;

		currentColor = newColor;
		
		//TODO: Change Level Color here
		
		//TODO: When sprites are added, change this region to use sprites
		#region change player color
		
		renderer.material.color = PlatformColor.ToColor(currentColor);
		
		#endregion
	}
}