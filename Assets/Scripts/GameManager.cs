using UnityEngine;
using System;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Current;

	public float TickInterval = 3f;

	//Fix to the money problem
	public double moneyFix;

	//Starting Resources
	public float Money = 1;
	public float MoneyGained = 0;
	public float Research = 0;
	public float ResearchGained = 0;
	public float CurrentPower = 0;
	public float PowerGained = 0;
	public float MaxPower = 50;
	public float StoragePercent = 0;



	//Windmill Resource
	public float WindmillPower;
	public float WindmillLifetime;

	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () 
	{
		
		// Set the power gain at an interval
		InvokeRepeating ("GainPower", 0.0f, TickInterval);

		//convert frames into seconds
		WindmillLifetime = WindMill.Current.Lifetime / 60;
		WindmillPower = WindMill.Current.GeneratedResource;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Convert Money to decimal places
		moneyFix = Math.Round (Money, 2);

		//Convert power to a %
		StoragePercent = (CurrentPower / MaxPower) * 100;
	}

	public void GainPower()
	{
		if (CurrentPower > MaxPower) 
		{
			CurrentPower = MaxPower;
			return;
		}
		else
			CurrentPower += PowerGained;


	}

	public void SellPower()
	{
		Money += CurrentPower;
		CurrentPower = 0;
	}
}
