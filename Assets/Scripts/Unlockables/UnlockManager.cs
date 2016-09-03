using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnlockManager : MonoBehaviour {
	public GameManager gameManager;

	public static UnlockManager Current;

	public float ResearchStationCost;
	public float BatteryCost;
	public float OfficeCost;
	public float AdvancedOfficeCost;
	public float SolarPanelCost;
	public float SolarPanelMCost;
	public float WindmillMCost;

	public GameObject[] ResearchStationUnlock;
	public GameObject[] BatteryUnlock;
	public GameObject[] OfficeUnlock;
	public GameObject[] AdvancedOfficeUnlock;
	public GameObject[] SolarPanelUnlock;
	public GameObject[] SolarPanelManagerUnlock;
	public GameObject[] WindmillManagerUnlock;

	void Awake()
	{
		Current = this;
	}


	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();

		//set the unlockable upgrades to non visible
		//make the researchstation icon non visible
		ResearchStationUnlock [3].SetActive (false);

		BatteryUnlock [0].SetActive (false);
		BatteryUnlock [1].SetActive (false);
		BatteryUnlock [2].SetActive (false);
		BatteryUnlock [3].SetActive (false);
		BatteryUnlock [4].SetActive (false);
		BatteryUnlock [5].SetActive (false);
		BatteryUnlock [6].SetActive (false);

		OfficeUnlock [0].SetActive (false);
		OfficeUnlock [1].SetActive (false);
		OfficeUnlock [2].SetActive (false);
		OfficeUnlock [3].SetActive (false);
		OfficeUnlock [4].SetActive (false);
		OfficeUnlock [5].SetActive (false);
		OfficeUnlock [6].SetActive (false);

		AdvancedOfficeUnlock [0].SetActive (false);
		AdvancedOfficeUnlock [1].SetActive (false);
		AdvancedOfficeUnlock [2].SetActive (false);
		AdvancedOfficeUnlock [3].SetActive (false);
		AdvancedOfficeUnlock [4].SetActive (false);
		AdvancedOfficeUnlock [5].SetActive (false);
		AdvancedOfficeUnlock [6].SetActive (false);

		SolarPanelUnlock [0].SetActive (false);
		SolarPanelUnlock [1].SetActive (false);
		SolarPanelUnlock [2].SetActive (false);
		SolarPanelUnlock [3].SetActive (false);
		SolarPanelUnlock [4].SetActive (false);
		SolarPanelUnlock [5].SetActive (false);
		SolarPanelUnlock [6].SetActive (false);
		SolarPanelUnlock [7].SetActive (false);

		SolarPanelManagerUnlock [0].SetActive (false);
		SolarPanelManagerUnlock [1].SetActive (false);
		SolarPanelManagerUnlock [2].SetActive (false);
		SolarPanelManagerUnlock [3].SetActive (false);
		SolarPanelManagerUnlock [4].SetActive (false);
		SolarPanelManagerUnlock [5].SetActive (false);

		WindmillManagerUnlock [0].SetActive (false);
		WindmillManagerUnlock [1].SetActive (false);
		WindmillManagerUnlock [2].SetActive (false);
		WindmillManagerUnlock [3].SetActive (false);
		WindmillManagerUnlock [4].SetActive (false);
		WindmillManagerUnlock [5].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResearchStationUnlockClick()
	{
		if (gameManager.Money >= ResearchStationCost) 
		{

			//remove cost and buy button
			ResearchStationUnlock [0].SetActive (false);
			ResearchStationUnlock [1].SetActive (false);
			ResearchStationUnlock [2].SetActive (false);
			ResearchStationUnlock [3].SetActive (true);

			//reveal other researches
			OfficeUnlock [0].SetActive (true);
			OfficeUnlock [1].SetActive (true);
			OfficeUnlock [2].SetActive (true);
			OfficeUnlock [3].SetActive (true);
			OfficeUnlock [4].SetActive (true);
			OfficeUnlock [5].SetActive (true);

			WindmillManagerUnlock [0].SetActive (true);
			WindmillManagerUnlock [1].SetActive (true);
			WindmillManagerUnlock [2].SetActive (true);
			WindmillManagerUnlock [3].SetActive (true);
			WindmillManagerUnlock [4].SetActive (true);
			WindmillManagerUnlock [5].SetActive (true);

			SolarPanelUnlock [0].SetActive (true);
			SolarPanelUnlock [1].SetActive (true);
			SolarPanelUnlock [2].SetActive (true);
			SolarPanelUnlock [3].SetActive (true);
			SolarPanelUnlock [4].SetActive (true);
			SolarPanelUnlock [5].SetActive (true);

			gameManager.Money -= ResearchStationCost;

		}
	}

	public void OfficeUnlockClick()
	{
		if (gameManager.Research >= OfficeCost) 
		{
			OfficeUnlock [0].SetActive (true);
			OfficeUnlock [1].SetActive (true);
			OfficeUnlock [2].SetActive (true);
			OfficeUnlock [3].SetActive (false);
			OfficeUnlock [4].SetActive (false);
			OfficeUnlock [5].SetActive (false);
			OfficeUnlock [6].SetActive (true);

			AdvancedOfficeUnlock [0].SetActive (true);
			AdvancedOfficeUnlock [1].SetActive (true);
			AdvancedOfficeUnlock [2].SetActive (true);
			AdvancedOfficeUnlock [3].SetActive (true);
			AdvancedOfficeUnlock [4].SetActive (true);
			AdvancedOfficeUnlock [5].SetActive (true);
			AdvancedOfficeUnlock [6].SetActive (false);

			gameManager.Research -= OfficeCost;
		}
	}

	public void WindmillMUnlockClick()
	{
		if (gameManager.Research >= WindmillMCost) 
		{
			WindmillManagerUnlock [0].SetActive (true);
			WindmillManagerUnlock [1].SetActive (true);
			WindmillManagerUnlock [2].SetActive (true);
			WindmillManagerUnlock [3].SetActive (false);
			WindmillManagerUnlock [4].SetActive (false);
			WindmillManagerUnlock [5].SetActive (false);
			WindmillManagerUnlock [6].SetActive (true);

			BatteryUnlock [0].SetActive (true);
			BatteryUnlock [1].SetActive (true);
			BatteryUnlock [2].SetActive (true);
			BatteryUnlock [3].SetActive (true);
			BatteryUnlock [4].SetActive (true);
			BatteryUnlock [5].SetActive (true);

			gameManager.Research -= WindmillMCost;
		}
	}

	public void SolarPanelUnlockClick()
	{
		if (gameManager.Research >= SolarPanelCost) 
		{
			SolarPanelUnlock [0].SetActive (true);
			SolarPanelUnlock [1].SetActive (true);
			SolarPanelUnlock [2].SetActive (true);
			SolarPanelUnlock [3].SetActive (false);
			SolarPanelUnlock [4].SetActive (false);
			SolarPanelUnlock [5].SetActive (false);
			SolarPanelUnlock [6].SetActive (true);
			SolarPanelUnlock [7].SetActive (true);

			SolarPanelManagerUnlock [0].SetActive (true);
			SolarPanelManagerUnlock [1].SetActive (true);
			SolarPanelManagerUnlock [2].SetActive (true);
			SolarPanelManagerUnlock [3].SetActive (true);
			SolarPanelManagerUnlock [4].SetActive (true);
			SolarPanelManagerUnlock [5].SetActive (true);


			gameManager.Research -= SolarPanelCost;
		}
	}

	public void SolarPanelMUnlockClick()
	{
		if (gameManager.Research >= SolarPanelMCost) 
		{
			SolarPanelManagerUnlock [0].SetActive (true);
			SolarPanelManagerUnlock [1].SetActive (true);
			SolarPanelManagerUnlock [2].SetActive (true);
			SolarPanelManagerUnlock [3].SetActive (false);
			SolarPanelManagerUnlock [4].SetActive (false);
			SolarPanelManagerUnlock [5].SetActive (false);


			gameManager.Research -= SolarPanelMCost;
		}
	}

	public void BatteryUnlockClick()
	{
		if (gameManager.Research >= BatteryCost) 
		{
			BatteryUnlock [0].SetActive (true);
			BatteryUnlock [1].SetActive (true);
			BatteryUnlock [2].SetActive (true);
			BatteryUnlock [3].SetActive (false);
			BatteryUnlock [4].SetActive (false);
			BatteryUnlock [5].SetActive (false);
			BatteryUnlock [6].SetActive (true);


			gameManager.Research -= BatteryCost;
		}
	}

	public void AdvancedOfficeUnlockClick()
	{
		if (gameManager.Research >= AdvancedOfficeCost) 
		{
			AdvancedOfficeUnlock [0].SetActive (true);
			AdvancedOfficeUnlock [1].SetActive (true);
			AdvancedOfficeUnlock [2].SetActive (true);
			AdvancedOfficeUnlock [3].SetActive (false);
			AdvancedOfficeUnlock [4].SetActive (false);
			AdvancedOfficeUnlock [5].SetActive (false);
			AdvancedOfficeUnlock [6].SetActive (true);


			gameManager.Research -= AdvancedOfficeCost;
		}
	}
}
