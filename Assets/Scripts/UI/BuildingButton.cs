using UnityEngine;
using System.Collections;

public class BuildingButton : MonoBehaviour {
	private UI_Controller UIController;
	private GameManager gameManager;

	//Interactable values
	public float cost;
	public GameObject BuildingToSpawn;
	public string Name_Description;
	public string Lifetime_Heat;
	public string Research_Heat;


	// Use this for initialization
	void Start () {
		UIController = UI_Controller.Current.GetComponent<UI_Controller> ();
		gameManager = GameManager.Current.GetComponent<GameManager> ();
	}

	public void OnClick()
	{
		// Takes the prefab to spawn set on each button 
		// Sends that info to the UI_Controller PrefabToSpawn
		UIController.PrefabToSpawn = BuildingToSpawn;
		UIController.Description.text = Name_Description;
		UIController.Price.text = "$" + cost.ToString();
		UIController.LifeTime_Heat.text = Lifetime_Heat;
		UIController.Research_Heat.text = Research_Heat;
		UIController.Cost = cost;

		//Check if the buildingtospawn is under a specific name
		//if so set the production and lifetime/maxheat of those objects
		if (BuildingToSpawn.name == ("Windmill")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.WindmillLifetime.ToString ();
			UIController.Research_HeatProduced.text = gameManager.WindmillPower + " Power";
		}

		if (BuildingToSpawn.name == ("Office")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.OfficeMaxHeat.ToString ();
			UIController.Research_HeatProduced.text = gameManager.OfficePowerSold + " Power";
		}

		if (BuildingToSpawn.name == ("AdvancedOffice")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.AOfficeMaxHeat.ToString ();
			UIController.Research_HeatProduced.text = gameManager.AOfficePowerSold + " Power";
		}


		if (BuildingToSpawn.name == ("ResearchStation")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.ResearchstationHeat.ToString ();
			UIController.Research_HeatProduced.text = gameManager.ResearchStationProduction + " Research";
		}

		if (BuildingToSpawn.name == ("Battery")) 
		{
			UIController.LifeTime_HeatAmount.text = "Max Power by " + gameManager.BatteryPowerGain ;
			UIController.Research_HeatProduced.text = "";
		}

		if (BuildingToSpawn.name == ("SolarPanel")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.SolarPanelTicks.ToString() ;
			UIController.Research_HeatProduced.text = gameManager.SolarPanelHeat + " Heat";
		}

		if (BuildingToSpawn.name == ("Generator")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.HeatConverterMaxHeat.ToString() ;
			UIController.Research_HeatProduced.text = gameManager.HeatConvertion + " Heat to Power";
		}
	}
}
