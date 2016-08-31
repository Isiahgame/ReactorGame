using UnityEngine;
using System.Collections;

public class BuildPlace : MonoBehaviour {

    // The block to be placed
    public GameObject AnchorPoint;

    private GameObject AttachedBuilding = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReactToMouseClick()
    {
        if (AttachedBuilding != null)
        {
			return;
        }
        else
        {
            // Spawn the new prefab
			AttachedBuilding = GameObject.Instantiate(UI_Controller.Current.PrefabToSpawn);

            //position the prefav at the anchor point
            AttachedBuilding.transform.position = AnchorPoint.transform.position;
            AttachedBuilding.transform.SetParent(AnchorPoint.transform);

        }
    }
}
