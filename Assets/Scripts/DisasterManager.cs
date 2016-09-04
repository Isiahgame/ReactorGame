using UnityEngine;
using System.Collections;

public class DisasterManager : MonoBehaviour {
	public GameManager gameManager;

	public float MoneyCheck = 1;
	public float EventWaitTime = 120;
	public float DisasterWaitTime = 60;
	public float DisasterThreshold = 750;
	public float RandomNumberBenefit;
	public float RandomNumberDisaster;

	//number ranges for triggers
	public float DisasterTrigger = 20;
	public float BenefitTrigger = 10;

	//penalties
	public float floodingPay = 0.4f;
	public float EarthQuakePay = 0.2f;
	public float PowerOutagePay = 0.6f;
	public float PowerOutageDuration; 

	//Benefits
	public float ExtraFundingBenefit = 1.3f;
	public float ResearchOverhaulBenefit = 1.5f;
	public float ResearchOverhaulDuration;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
	
		//check every second if the player has gone over the trigger amount
		InvokeRepeating ("CheckIfOverMoney", 0.0f, MoneyCheck);

		//always run randombenefit everry 2 mins
		InvokeRepeating ("RandomBenefit", 0.0f, EventWaitTime);
	}
	
	// Update is called once per frame
	void Update () {
		//Countdown the time for a disaster to possibly happen
		DisasterWaitTime -= Time.deltaTime;

	}

	public void CheckIfOverMoney()
	{
		
		if (gameManager.Money > DisasterThreshold) 
		{
			//if its time to check for a disaster
			if (DisasterWaitTime <= 0) 
			{
				RandomDisaster ();
				DisasterWaitTime = 180;
			}
		}
			

	}

	public void RandomDisaster()
	{
		//roll for a number
		RandomNumberDisaster = Random.Range (0, 100);

		//if below the trigger make a disaster
		if (RandomNumberDisaster < DisasterTrigger) 
		{
			//roll for the disaster
			float D = Random.Range (0, 3);

			if (D < 1)
				Flooding ();

			if (D < 2 && D >= 1)
				EarthQuake ();

			if (D >= 2 && D <= 3)
				PowerOutage ();
		}
	}

	public void RandomBenefit()
	{
		//roll for a number
		RandomNumberBenefit = Random.Range (0, 100);

		//if below the benefit give a benefit
		if (RandomNumberBenefit <= BenefitTrigger) 
		{
			//roll the benefit
			float B = Random.Range (0, 2);

			if (B < 1)
				ExtraFunding ();

			if (B <= 2 && B >= 1)
				ResearchOverhaul ();
		}
	}
		
	public void Flooding()
	{
		gameManager.Money *= floodingPay;
		Debug.Log ("The Office has been flooded!!! We have to pay for the repairs");
	}

	public void EarthQuake()
	{
		gameManager.Money *= EarthQuakePay;
		Debug.Log ("An earthquake has hit, you have lost some money");
	}

	public void PowerOutage()
	{
		Debug.Log ("We have lost our power!!!");

		PowerOutageDuration = Random.Range (10, 40);
		PowerOutageDuration -= Time.deltaTime;

		if (PowerOutageDuration > 0) 
		{
			gameManager.PowerGained *= PowerOutagePay;
		}

		Debug.Log ("We have regained our power!!!");

		PowerOutageDuration = Random.Range (10,40);
	}

	public void ResearchOverhaul()
	{
		ResearchOverhaulDuration = Random.Range (10,30);

		ResearchOverhaulDuration -= Time.deltaTime;

		Debug.Log ("Our Scientists have been inspired");

		if (ResearchOverhaulDuration >= 0) 
		{
			gameManager.ResearchGained *= ResearchOverhaulBenefit;
		}

		ResearchOverhaulDuration = Random.Range (10,30);
	}

	public void ExtraFunding()
	{
		Debug.Log ("We have gained extra funding!!!");

		gameManager.Money *= ExtraFundingBenefit;
	}
}
