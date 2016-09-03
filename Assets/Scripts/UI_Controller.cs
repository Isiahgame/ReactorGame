using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Controller : MonoBehaviour {
	public EventSystem LevelEventSystem;

	private GameManager gameManager;

	public static UI_Controller Current;

	//Building to Spawn
	public GameObject PrefabToSpawn;
	public float Cost; 

	//Resource Variables
	public Text MoneyGained;
	public Text ResearchGained;
	public Text PowerGained;
	public Text MaxPower;
	public Text StoragePercent;
	public Slider StorageRepresentation;

	//Building Description
	public Text Description;
	public Text Price;
	public Text LifeTime_Heat;
	public Text LifeTime_HeatAmount;
	public Text Research_Heat;
	public Text Research_HeatProduced;

	public GameObject[] ActiveUI;

	void Awake()
	{
		Current = this;
	}
	// Use this for initialization
	void Start () {
		gameManager = GameManager.Current.GetComponent<GameManager> ();

		Description.text = "";
		Price.text = "";
		LifeTime_Heat.text = "";
		LifeTime_HeatAmount.text = "";
		Research_Heat.text = "";
		Research_HeatProduced.text = "";
	}

	// Update is called once per frame
	void Update () {
		// Set the resource Variables
		MoneyGained.text = "$" + gameManager.moneyFix.ToString("0.00") + " +" + gameManager.MoneyGained.ToString("0.##");
		ResearchGained.text = gameManager.Research.ToString("0.##") + " +" + gameManager.ResearchGained.ToString("0.##");
		PowerGained.text = gameManager.CurrentPower.ToString("0.##") + " +" + gameManager.PowerGained.ToString("0.##");
		MaxPower.text = gameManager.MaxPower.ToString("0.##");
		StoragePercent.text = gameManager.StoragePercent.ToString("0.##") + "%";
		StorageRepresentation.value = gameManager.StoragePercent;

	// Has the user clicked the primary mouse button
		if (Input.GetMouseButtonDown (0)) 
		{
			// Is the current mouse location over the UI?
			if (LevelEventSystem.IsPointerOverGameObject ()) {
				
			} else 
			{
				//Setup the ray based on the mosue location
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// Perform a raycast to determine what we have hit
				RaycastHit HitResults;
				if (Physics.Raycast (ray, out HitResults)) 
				{
					// Retrieve the gameobject that was hit
					GameObject HitObject = HitResults.collider.gameObject;

					BuildPlace buildplace = HitObject.GetComponent<BuildPlace> ();
					if (buildplace != null) {
						buildplace.ReactToMouseClick ();
					} else {
						// Attempt to find buildplace as parent
						buildplace = HitObject.GetComponentInParent<BuildPlace> ();
						if (buildplace != null) {
							buildplace.ReactToMouseClick ();
						}
					}
				}
			}
		}

		// Has the user clicked the right mouse button
		if (Input.GetMouseButtonDown (1)) 
		{
			if (LevelEventSystem.IsPointerOverGameObject ()) {

			} else 
			{
				//Setup the ray based on the mosue location
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// Perform a raycast to determine what we have hit
				RaycastHit HitResults;
				if (Physics.Raycast (ray, out HitResults)) 
				{
					// Retrieve the gameobject that was hit
					GameObject HitObject = HitResults.collider.gameObject;

					BuildPlace buildplace = HitObject.GetComponent<BuildPlace> ();
					if (buildplace != null) {
						buildplace.ReactToMouseClick ();
					} else {
						// Attempt to find buildplace as parent
						buildplace = HitObject.GetComponentInParent<BuildPlace> ();
						if (buildplace != null) {
							buildplace.DestroyTheObject ();
						}
					}
				}
			}
		}
	}

	public void ResearchScreen()
	{
		ActiveUI [0].SetActive (true);
	}

	public void UpgradeScreen ()
	{
		ActiveUI [1].SetActive (true);
	}

	public void HelpScreen()
	{
		ActiveUI [2].SetActive (true);
	}

	public void CloseResearch()
	{
		ActiveUI [0].SetActive (false);
	}

	public void CloseUpgrades()
	{
		ActiveUI [1].SetActive (false);
	}

	public void CloseHelp()
	{
		ActiveUI [2].SetActive (false);
	}
}
