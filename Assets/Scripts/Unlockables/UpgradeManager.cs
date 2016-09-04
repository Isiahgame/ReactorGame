using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

	public static UpgradeManager Current;

	public float BaseLevel = 1;

	//building Lvl
	public Text WindmillLvlText;
	public Text WindmillLifeLVLText;
	public Text OfficeLVlText;
	public Text ResearchLvlText;
	public Text BatteryLVLText;
	public Text SolarHeatLVLText;
	public Text SolarLifeLVLText;
	public Text GenHeatLVLText;
	public Text GentConversionLVLText;

	//Building Cost
	public Text WindmillCostText;
	public Text WindmillLifeCostText;
	public Text OfficeCostText;
	public Text ResearchCostText;
	public Text BatteryCostText;
	public Text SolarHeatCostText;
	public Text SolarLifeCostText;
	public Text GenHeatCostText;
	public Text GentConversionCostText;

	//Float Values
	public float WindmillLvl = 1;
	public float WindmillLifeLVL = 1;
	public float OfficeLVl = 1;
	public float ResearchLvl = 1;
	public float BatteryLVL = 1;
	public float SolarHeatLVL = 1;
	public float SolarLifeLVL = 1;
	public float GenHeatLVL = 1;
	public float GenConversionLVL = 1;

	//Building Cost
	public float WindmillCost;
	public float WindmillLifeCost;
	public float OfficeCost;
	public float ResearchCost;
	public float BatteryCost;
	public float SolarHeatCost;
	public float SolarLifeCost;
	public float GenHeatCost;
	public float GenConversionCost;


	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () {
		WindmillCost = 250;
		WindmillLifeCost = 15;
		OfficeCost = 1000;
		ResearchCost = 2500;
		BatteryCost = 300;
		SolarHeatCost = 500;
		SolarLifeCost = 1000;
		GenHeatCost = 1000;
		GenConversionCost = 400;
	}
	
	// Update is called once per frame
	void Update () {

		//display the updates costs and levels
		WindmillCostText.text = "$"+ WindmillCost.ToString ();
		WindmillLvlText.text = WindmillLvl.ToString ();
		WindmillLifeCostText.text = "$"+ WindmillLifeCost.ToString ();
		WindmillLifeLVLText.text = WindmillLifeLVL.ToString ();
		OfficeCostText.text = "$"+ OfficeCost.ToString ();
		OfficeLVlText.text = OfficeLVl.ToString ();
		ResearchCostText.text = "$"+ ResearchCost.ToString ();
		ResearchLvlText.text = ResearchLvl.ToString ();
		BatteryCostText.text = "$"+ BatteryCost.ToString ();
		BatteryLVLText.text = BatteryLVL.ToString ();
		SolarHeatLVLText.text = SolarHeatLVL.ToString ();
		SolarHeatCostText.text = "$"+ SolarHeatCost.ToString ();
		SolarLifeCostText.text = SolarLifeCost.ToString ();
		SolarLifeLVLText.text = SolarHeatLVL.ToString ();
		GenHeatCostText.text = "$"+ GenHeatCost.ToString ();
		GenHeatLVLText.text = GenHeatLVL.ToString ();
		GentConversionCostText.text = "$"+ GenConversionCost.ToString ();
		GentConversionLVLText.text = GenConversionLVL.ToString ();
			
	}


	public void WindmillLevelClick()
	{
		if (GameManager.Current.Money >= WindmillCost) 
		{
			//increase the level
			WindmillLvl += BaseLevel;
			//scale the costs with level
			WindmillCost = WindmillCost * (90 * WindmillLvl / 100);
		}
	}

	public void WindmillLifeLevelClick()
	{
		if (GameManager.Current.Money >= WindmillLifeCost) 
		{
			//increase the level
			WindmillLifeLVL += BaseLevel;
			//scale the costs with level
			WindmillLifeCost = WindmillLifeCost * (90 * WindmillLifeLVL / 100);
		}
	}

	public void OfficeSellClick()
	{
		if (GameManager.Current.Money >= OfficeCost) 
		{
			//increase the level
			OfficeLVl+= BaseLevel;
			//scale the costs with level
			OfficeCost = OfficeCost * (90 * BatteryLVL / 100);
		}
	}
		
	public void BatteryClick()
	{
		if (GameManager.Current.Money >= BatteryCost) 
		{
			//increase the level
			BatteryLVL += BaseLevel;
			//scale the costs with level
			BatteryCost = BatteryCost * (90 * BatteryLVL / 100);
		}
	}

	public void SolarPowerClick()
	{
		if (GameManager.Current.Money >= SolarHeatCost) 
		{
			//increase the level
			SolarHeatLVL += BaseLevel;
			//scale the costs with level
			SolarHeatCost = SolarHeatCost * (90 * SolarHeatLVL / 100);
		}
	}

	public void SolarLifeClick()
	{
		if (GameManager.Current.Money >= SolarLifeCost) 
		{
			//increase the level
			SolarLifeLVL += BaseLevel;
			//scale the costs with level
			SolarLifeCost = SolarLifeCost * (90 * SolarLifeLVL / 100);
		}
	}

	public void GenMaxHeatClick()
	{
		if (GameManager.Current.Money >= GenHeatCost) 
		{
			//increase the level
			GenHeatLVL += BaseLevel;
			//scale the costs with level
			GenHeatCost = GenHeatCost * (90 * GenHeatLVL / 100);
		}
	}

	public void GenConvertClick()
	{
		if (GameManager.Current.Money >= GenConversionCost) 
		{
			//increase the level
			GenConversionLVL+= BaseLevel;
			//scale the costs with level
			GenConversionCost = GenConversionCost * (90 * GenConversionLVL / 100);
		}
	}

	public void ResearchStationClick()
	{
		if (GameManager.Current.Money >= ResearchCost) 
		{
			//increase the level
			ResearchLvl+= BaseLevel;
			//scale the costs with level
			ResearchCost = ResearchCost * (90 * ResearchLvl / 100);
		}
	}
}
