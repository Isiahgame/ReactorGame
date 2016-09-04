using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour {


	public void MainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene ("MainLevel");
	}

	public void Credits()
	{
		SceneManager.LoadScene ("Credits");
	}

	public void Secret()
	{
		SceneManager.LoadScene ("Secret");
	}
}
