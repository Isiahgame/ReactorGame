using UnityEngine;
using System.Collections;

public class ReseachStation : MonoBehaviour {

	private GameManager gameManager;

	public static ReseachStation Current;

	//Properties
	public float TickInterval = 1f;
	public float CurrentHeat = 0;
	public float MaxHeat = 1f;
	public float Research = 1f;

	void awake()
	{
		Current = this;	
	}

	// Use this for initialization
	void Start () {

		//repeat at an interval
		InvokeRepeating ("AddResearch", 0.0f, TickInterval);

		gameManager = GameManager.Current.GetComponent<GameManager> ();
		gameManager.ResearchGained += Research;
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddResearch()
	{
		//add the research
		gameManager.Research += Research;
	}

	public void OnTriggerEnter (Collider otherObject)
	{
		//check for nearby generators
		if (otherObject.tag == ("GenDetector"))
		{
			InvokeRepeating ("AddHeat", 0.0f, TickInterval);
		}
	}

	public void AddHeat()
	{
		CurrentHeat += gameManager.SolarPanelHeat;
	}

	void OnDestroy ()
	{
		gameManager.ResearchGained -= Research;
	}
}
