using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Current;

	public float TickInterval = 3f;

	//Starting Resources
	public float Money = 1f;
	public float MoneyGained = 0f;
	public float Research = 0f;
	public float ResearchGained = 0f;
	public float CurrentPower = 0f;
	public float PowerGained = 0f;
	public float MaxPower = 50f;
	public float StoragePercent = 0f;

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

		WindmillLifetime = WindMill.Current.Lifetime;
		WindmillPower = WindMill.Current.GeneratedResource;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
