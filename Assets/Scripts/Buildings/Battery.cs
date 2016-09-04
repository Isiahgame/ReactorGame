using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	private GameManager gameManager;

	public float MaxPowerGain = 100f;
	public float startingMaxPowerGain = 100;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
		//increase the max power
		gameManager.MaxPower += MaxPowerGain;

	}

	// Update is called once per frame
	void Update () {
		// increase the power gained by the buildings level
		if (UpgradeManager.Current.BatteryLVL > UpgradeManager.Current.BaseLevel)
			MaxPowerGain = startingMaxPowerGain * (50 * UpgradeManager.Current.BatteryLVL / 100);
	}

	void OnDestroy ()
	{
		gameManager.MaxPower -= MaxPowerGain;
	}
}
