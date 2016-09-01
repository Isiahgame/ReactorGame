using UnityEngine;
using System.Collections;

public class BuildingButton : MonoBehaviour {
	private UI_Controller UIController;
	private GameManager gameManager;

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

	// Update is called once per frame
	void Update () {
	
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

		if (BuildingToSpawn.name == ("Cube")) 
		{
			UIController.LifeTime_HeatAmount.text = gameManager.WindmillLifetime.ToString ();
			UIController.Research_HeatProduced.text = gameManager.WindmillPower + " Power";
		}
	}
}
