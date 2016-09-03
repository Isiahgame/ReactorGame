using UnityEngine;
using System.Collections;

public class BuildPlace : MonoBehaviour {

    // The block to be placed
    public GameObject AnchorPoint;

    private GameObject AttachedBuilding = null;

    public void ReactToMouseClick()
    {
        if (AttachedBuilding != null)
        {
			return;
        }
        else
        {
			if (GameManager.Current.moneyFix >=  UI_Controller.Current.Cost) {

				// Spawn the new prefab
				GameManager.Current.Money -= UI_Controller.Current.Cost;
				AttachedBuilding = GameObject.Instantiate (UI_Controller.Current.PrefabToSpawn);

				//position the prefav at the anchor point
				AttachedBuilding.transform.position = AnchorPoint.transform.position;
				AttachedBuilding.transform.SetParent (AnchorPoint.transform);
			} else
				Debug.Log ("Not enough money!");
        }
    }

	public void DestroyTheObject()
	{
		if (AttachedBuilding != null)
		{
			//Remove the Object
			GameObject.Destroy (AttachedBuilding);
			AttachedBuilding = null;
			return;
		}
	}
}
