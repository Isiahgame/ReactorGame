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

	//Windmill Properties
	public float WindmillPower = 0.15f;
	public float WindmillLifetime = 10;

	//Office properties
	public float OfficePowerSold = 10;
	public float OfficeMaxHeat = 10;
	public float OfficeTotalPower;

	//ResearchStation properties
	public float ResearchstationHeat = 1;
	public float ResearchStationProduction = 1;

	//Battery properties
	public float BatteryPowerGain = 100f;

	//SolarPanel Properties
	public float SolarPanelTicks = 100f;
	public float SolarPanelHeat = 3;

	//HeatConverterProperties
	public float HeatConverterMaxHeat = 25;
	public float HeatConvertion = 3;

	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () 
	{
		// Set the power gain at an interval
		InvokeRepeating ("GainPower", 0.0f, TickInterval);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Convert Money to decimal places
		moneyFix = Math.Round (Money, 2);

		//Convert power to a %
		StoragePercent = (CurrentPower / MaxPower) * 100;

		//If current power is more tahn maxpower dont allow it to increase more than maxpower
		if (CurrentPower > MaxPower) 
		{
			CurrentPower = MaxPower;
			return;
		} 
	}

	public void GainPower()
	{
		//Increase power according to the powergained
		CurrentPower += PowerGained;
	}



	public void SellPower()
	{
		//Sell the power on a button click
		Money += CurrentPower;
		CurrentPower = 0;
	}
}
