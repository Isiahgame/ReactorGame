using UnityEngine;
using System.Collections;

public class Office : MonoBehaviour {
	private GameManager gameManager;

	public static Office Current;

	// Properties
	public float TickInterval = 1f;
	public float MaxHeat = 10;
	public float CurrentHeat = 0;
	public float PowerSold;
	public float startingPowerSold;

	void awake()
	{
		Current = this;	
	}

	// Use this for initialization
	void Start () {

		//Add money at an interval
		InvokeRepeating ("AddMoney", 0.0f, TickInterval);

		gameManager = GameManager.Current.GetComponent<GameManager> ();
		gameManager.OfficeTotalPower += PowerSold;
	}

	// Update is called once per frame
	void Update () {
		//Check if building is overheating
		if (CurrentHeat >= MaxHeat)
			DestroyBuilding();

		if (UpgradeManager.Current.OfficeLVl > UpgradeManager.Current.BaseLevel)
			PowerSold = startingPowerSold * (100 * UpgradeManager.Current.OfficeLVl / 100);
	}

	public void DestroyBuilding()
	{
		Destroy (this.gameObject);
	}

	public void AddMoney()
	{

		//Is the Current power gain more than the total amount of power sold?
		if (gameManager.CurrentPower >= gameManager.OfficeTotalPower) 
		{
			gameManager.MoneyGained = gameManager.OfficeTotalPower;
			gameManager.Money += gameManager.MoneyGained;
			gameManager.CurrentPower -= gameManager.MoneyGained;
		}
		// Sell all the current power if less than the total amount of power being sold
		else if (gameManager.CurrentPower <= PowerSold) 
		{
			gameManager.MoneyGained = gameManager.CurrentPower;
			gameManager.Money += gameManager.CurrentPower;
			gameManager.CurrentPower = 0;
			return;
		} 
	}

	public void OnTriggerEnter (Collider otherObject)
	{
		// Check for nearby HeatGenerators
		if (otherObject.tag == ("GenDetector"))
		{
			InvokeRepeating ("AddHeat", 0.0f, TickInterval);
		}
	}

	public void AddHeat()
	{
		//Increse Objects heat
		CurrentHeat += gameManager.SolarPanelHeat;
	}

	void OnDestroy ()
	{
		//Remove the total amount of power that can be sold at one time
		gameManager.OfficeTotalPower -= PowerSold;
	}
}
