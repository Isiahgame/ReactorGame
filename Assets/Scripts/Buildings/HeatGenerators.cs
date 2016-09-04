using UnityEngine;
using System.Collections;

public class HeatGenerators : MonoBehaviour {
	public static HeatGenerators Current;

	//properties
	public float Lifetime = 6000;
	public float startingLifetime = 6000;

	void awake()
	{
		Current = this;	
	}

	// Update is called once per frame
	void Update () {
		DestroyBuilding ();

		if (UpgradeManager.Current.SolarLifeLVL > UpgradeManager.Current.BaseLevel)
			Lifetime = startingLifetime * (50 * UpgradeManager.Current.SolarLifeLVL / 100);
	}

	public void DestroyBuilding()
	{
		Lifetime -= Time.deltaTime;

		if (Lifetime <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
