using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Controller : MonoBehaviour {
	public EventSystem LevelEventSystem;

	public static UI_Controller Current;

	public Text MoneyGained;
	public Text ResearchGained;
	public Text PowerGained;
	public Text MaxPower;
	public Text StoragePercent;
	public Slider StorageRepresentation;


	void Awake()
	{
		Current = this;
	}
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		MoneyGained.text = GameManager.Current.Money + " +" + GameManager.Current.MoneyGained;
		ResearchGained.text = GameManager.Current.Research + " +" + GameManager.Current.ResearchGained;
		PowerGained.text = GameManager.Current.CurrentPower + " +" + GameManager.Current.PowerGained;
		MaxPower.text = GameManager.Current.MaxPower.ToString();
		StoragePercent.text = GameManager.Current.StoragePercent + "%";
		StorageRepresentation.value = GameManager.Current.StoragePercent;

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
			
	}
}
