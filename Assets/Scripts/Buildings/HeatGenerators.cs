using UnityEngine;
using System.Collections;

public class HeatGenerators : MonoBehaviour {
	public static HeatGenerators Current;

	//properties
	public float Lifetime = 6000;

	void awake()
	{
		Current = this;	
	}

	// Update is called once per frame
	void Update () {
		DestroyBuilding ();
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
