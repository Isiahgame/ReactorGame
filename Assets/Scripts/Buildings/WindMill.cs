using UnityEngine;
using System.Collections;

public class WindMill : MonoBehaviour {
	private GameManager gameManager;

	public static WindMill Current;

	//Properties
	public float GeneratedResource = 0.15f;
	public float Lifetime = 600;
	public float startingLifetime = 600;
	public float startingResource = 0.15f;
	public float timer;

	void awake()
	{
		Current = this;	
	}

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
		gameManager.PowerGained += gameManager.WindmillPower;
		timer = gameManager.WindmillLifetime;

	}
	
	// Update is called once per frame
	void Update () {
		DestroyBuilding ();

		if (UpgradeManager.Current.WindmillLifeLVL > UpgradeManager.Current.BaseLevel)
			Lifetime = startingLifetime + startingLifetime * (500 * UpgradeManager.Current.WindmillLifeLVL / 100);

		if (UpgradeManager.Current.WindmillLvl > UpgradeManager.Current.BaseLevel)
			GeneratedResource = startingResource + startingResource * (25 * UpgradeManager.Current.WindmillLvl / 100);
	}

	public void DestroyBuilding()
	{
		//check if the tiemr of the building is up
		timer -= Time.deltaTime;

		if (timer <= 0) {
			if (UnlockManager.Current.WindmillM == true)
			{
				timer = Lifetime;
                gameManager.Money -= 1;
			}
			else
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
