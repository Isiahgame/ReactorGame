using UnityEngine;
using System.Collections;

public class HeatGenerators : MonoBehaviour {
	public static HeatGenerators Current;

	//properties
	public float Lifetime = 6000;
	public float startingLifetime = 6000;
	public float timer;

	void awake()
	{
		Current = this;	
	}

	void Start ()
	{
		timer = Lifetime;
	}


	// Update is called once per frame
	void Update () {
		DestroyBuilding ();

		if (UpgradeManager.Current.SolarLifeLVL > UpgradeManager.Current.BaseLevel)
			Lifetime = startingLifetime * (50 * UpgradeManager.Current.SolarLifeLVL / 100);
	}

	public void DestroyBuilding()
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			if (UnlockManager.Current.SolarManager == true)
			{
				timer = Lifetime;
			}
			else
				Destroy (this.gameObject);
		}
	}
}
