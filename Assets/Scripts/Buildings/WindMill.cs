﻿using UnityEngine;
using System.Collections;

public class WindMill : MonoBehaviour {
	private GameManager gameManager;

	public static WindMill Current;

	//Properties
	public float GeneratedResource = 0.15f;
	public float Lifetime = 600;
	public float startingLifetime = 600;
	public float startingResource = 0.15f;

	void awake()
	{
		Current = this;	
	}

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
		gameManager.PowerGained += GeneratedResource;

	}
	
	// Update is called once per frame
	void Update () {
		DestroyBuilding ();

		if (UpgradeManager.Current.WindmillLifeLVL > UpgradeManager.Current.BaseLevel)
			Lifetime = startingLifetime * (500 * UpgradeManager.Current.WindmillLifeLVL / 100);

		if (UpgradeManager.Current.WindmillLvl > UpgradeManager.Current.BaseLevel)
			GeneratedResource = startingResource * (25 * UpgradeManager.Current.WindmillLvl / 100);
	}

	public void DestroyBuilding()
	{
		//check if the tiemr of the building is up
		Lifetime -= Time.deltaTime;

		if (Lifetime <= 0) {
			//destroy the building
			Destroy (this.gameObject);
		}
	}

	void OnDestroy ()
	{
		//remove the powergained from this object
		gameManager.PowerGained -= GeneratedResource;
	}
}
