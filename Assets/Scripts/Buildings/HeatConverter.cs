using UnityEngine;
using System.Collections;

public class HeatConverter : MonoBehaviour {
	public GameManager gameManager;

	public float TickInterval = 1f;
	public float HeatConvertion = 3f;
	public float CurrentHeat = 0f;
	public float MaxHeat = 25f;

	public float startingHeatconvertion = 3;
	public float startingMaxHeat = 25;

	// Use this for initialization
	void Start () {
		//Add power at an interval
		InvokeRepeating ("AddPower", 0.0f, TickInterval);

		gameManager = GameManager.Current.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentHeat >= MaxHeat)
			Destroy(this.gameObject);

		if (UpgradeManager.Current.GenHeatLVL > UpgradeManager.Current.BaseLevel)
			MaxHeat = startingMaxHeat * (100 * UpgradeManager.Current.GenHeatLVL / 100);

		if (UpgradeManager.Current.GenConversionLVL > UpgradeManager.Current.BaseLevel)
			HeatConvertion = startingHeatconvertion * (100 * UpgradeManager.Current.GenConversionLVL / 100);
	}

	public void AddPower()
	{
		//convert the heat to power
		CurrentHeat -= HeatConvertion;
		gameManager.CurrentPower += HeatConvertion;
	}

	public void OnTriggerEnter (Collider otherObject)
	{
		if (otherObject.tag == ("GenDetector"))
		{
			InvokeRepeating ("AddHeat", 0.0f, TickInterval);
		}
	}

	public void AddHeat()
	{
		CurrentHeat += gameManager.SolarPanelHeat;
	}
}
