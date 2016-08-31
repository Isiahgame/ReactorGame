using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Current;

	public float Money = 1;
	public float MoneyGained = 0;
	public float Research = 0;
	public float ResearchGained = 0;
	public float CurrentPower = 0;
	public float PowerGained = 0;
	public float MaxPower = 50;
	public float StoragePercent = 0;

	void Awake()
	{
		Current = this;
	}

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		StoragePercent = (CurrentPower / MaxPower) * 100;
	}
}
