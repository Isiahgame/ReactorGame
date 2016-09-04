using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager Current;
	public UpgradeManager upgradeManager;

	public float TickInterval = 3f;

	//Fix to the money problem
	public double moneyFix;

	//Starting Resources starting properties to prevent UI breaking
	public float Money = 1;
	public float MoneyGained = 0;
	public float Research = 0;
	public float ResearchGained = 0;
	public float CurrentPower = 0;
	public float PowerGained = 0;
	public float MaxPower = 50;
	public float StoragePercent = 0;
	public float MoneyToWin = 100000;

	//Windmill Properties starting properties to prevent UI breaking
	public float WindmillPower = 0.15f;
	public float WindmillLifetime = 10;
	public float StartingWindmillPower = 0.15f;
	public float startingWindmillLifetime = 10;

	//Office properties starting properties to prevent UI breaking
	public float OfficePowerSold = 10;
	public float OfficeMaxHeat = 10;
	public float startingOfficePowerSold = 10;
	public float OfficeTotalPower;

	//Office properties starting properties to prevent UI breaking
	public float AOfficePowerSold = 10;
	public float AOfficeMaxHeat = 200;
	public float startingAOfficePowerSold = 200;

	//ResearchStation properties starting properties to prevent UI breaking
	public float ResearchstationHeat = 1;
	public float ResearchStationProduction = 1;
	public float startingResearchStationProduction = 1;

	//Battery properties starting properties to prevent UI breaking 
	public float BatteryPowerGain = 100f;
	public float startingBatteryPowerGain = 100f;

	//SolarPanel Properties starting properties to prevent UI breaking
	public float SolarPanelTicks = 100f;
	public float SolarPanelHeat = 3;
	public float startingSolarPanelTicks = 100f;
	public float startingSolarPanelHeat = 3;

	//HeatConverterProperties starting properties to prevent UI breaking
	public float HeatConverterMaxHeat = 25;
	public float HeatConvertion = 3;
	public float startingHeatConverterMaxHeat = 25;
	public float startingHeatConvertion = 3;

	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () 
	{
		upgradeManager = UpgradeManager.Current.GetComponent<UpgradeManager> ();

		// Set the power gain at an interval
		InvokeRepeating ("GainPower", 0.0f, TickInterval);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moneyFix >= MoneyToWin)
			SceneManager.LoadScene ("EndScreen");
		
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

		//update the properties when the buildings level
		if (upgradeManager.WindmillLvl > upgradeManager.BaseLevel)
			WindmillPower = StartingWindmillPower * (25 * upgradeManager.WindmillLvl / 100);
		
		if (upgradeManager.WindmillLifeLVL > upgradeManager.BaseLevel)
			WindmillLifetime = startingWindmillLifetime * (50 * upgradeManager.WindmillLifeLVL / 100);

		if (upgradeManager.OfficeLVl > upgradeManager.BaseLevel)
			OfficePowerSold = startingOfficePowerSold * (100 * upgradeManager.OfficeLVl / 100);

		if (upgradeManager.OfficeLVl > upgradeManager.BaseLevel)
			AOfficePowerSold = startingAOfficePowerSold * (100 * upgradeManager.OfficeLVl / 100);

		if (upgradeManager.ResearchLvl > upgradeManager.BaseLevel)
			ResearchStationProduction = startingResearchStationProduction * (25 * upgradeManager.ResearchLvl / 100);

		if (upgradeManager.SolarHeatLVL > upgradeManager.BaseLevel)
			SolarPanelHeat = startingSolarPanelHeat * (25 * upgradeManager.SolarHeatLVL / 100);

		if (upgradeManager.SolarLifeLVL > upgradeManager.BaseLevel)
			SolarPanelTicks = startingSolarPanelTicks * (50 * upgradeManager.SolarLifeLVL / 100);

		if (upgradeManager.GenConversionLVL > upgradeManager.BaseLevel)
			HeatConvertion = startingHeatConvertion * (25 * upgradeManager.GenConversionLVL / 100);

		if (upgradeManager.GenHeatLVL > upgradeManager.BaseLevel)
			HeatConverterMaxHeat = startingHeatConverterMaxHeat * (100 * upgradeManager.GenHeatLVL / 100);

		if (upgradeManager.BatteryLVL > upgradeManager.BaseLevel)
			BatteryPowerGain = startingBatteryPowerGain * (50 * upgradeManager.BatteryLVL / 100);


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
