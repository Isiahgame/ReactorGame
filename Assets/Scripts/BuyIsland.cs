using UnityEngine;
using System.Collections;

public class BuyIsland : MonoBehaviour {
	public static BuyIsland Current;

	public float cost;
	public GameObject blocker;
	public bool bought = false;

	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	public void OnClick()
	{
		//check if the player has enough money
		if (GameManager.Current.Money >= cost) 
		{
			//disable the buy button
			GameManager.Current.Money -= cost;
			blocker.SetActive (false);
			this.gameObject.SetActive (false);
			bought = true;
		} 
		else
			Debug.Log ("NOT ENOUGH MONEY!!");
	}
}
