using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera[] ActiveCameras;
	public GameObject IslandUnlocker;

	public Button PowerPlant1;
	public Button PowerPlant2;

	// Use this for initialization
	void Start () 
	{
		//set button to greyed out
		PowerPlant1.interactable = false;
	}

	// switch to powerplant1
	public void SwitchPowerPlant1()
	{
		if (BuyIsland.Current.bought == false) 
		{
			IslandUnlocker.SetActive (false);
		}

		PowerPlant2.interactable = true;
		PowerPlant1.interactable = false;
		ActiveCameras [0].enabled = true;
		ActiveCameras [1].enabled = false;
	}

	//switch to powerplant2
	public void SwitchPowerPlant2 ()
	{
		//check if the second island is bought
		if (BuyIsland.Current.bought == false) 
		{
			//display a buy button if not bought
			IslandUnlocker.SetActive (true);
		}

		PowerPlant2.interactable = false;
		PowerPlant1.interactable = true;
		ActiveCameras [0].enabled = false;
		ActiveCameras [1].enabled = true;
	}
}
