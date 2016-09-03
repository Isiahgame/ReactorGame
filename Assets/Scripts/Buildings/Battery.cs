using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	private GameManager gameManager;

	public float MaxPowerGain = 100f;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
		//increase the max power
		gameManager.MaxPower += MaxPowerGain;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnDestroy ()
	{
		gameManager.MaxPower -= MaxPowerGain;
	}
}
