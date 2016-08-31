using UnityEngine;
using System.Collections;

public class WindMill : MonoBehaviour {
	private GameManager gameManager;

	public static WindMill Current;

	public float cost = 1;
	public float GeneratedResource = 0.15f;
	public float Lifetime = 600;

	void awake()
	{
		Current = this;	
	}

	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();
		gameManager.PowerGained += GeneratedResource;
		gameManager.Money -= cost;
	}
	
	// Update is called once per frame
	void Update () {
		DestroyBuilding ();
	}

	public void DestroyBuilding()
	{
		Lifetime -= Time.deltaTime;

		if (Lifetime <= 0) {
			gameManager.PowerGained -= GeneratedResource;
			Destroy (this.gameObject);
		}
	}
}
