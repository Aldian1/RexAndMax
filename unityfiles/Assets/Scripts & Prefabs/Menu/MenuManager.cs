using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	public GameObject splash,main,options,levelselect;


	// Use this for initialization
	void Start () {
	
	}
	public void OpenWebsite()
	{
		Application.OpenURL("http://maxandrex.com/");
	}

	public void Nextoverlay(Button button)
	{
		Debug.Log ("press");
		if (button.name == "Main") {
			splash.SetActive (false);
			main.SetActive (true);
		}
		if (button.name == "Options") {
			main.SetActive (false);
			options.SetActive (true);
		}

		if (button.name == "Back") {
			main.SetActive (true);
			options.SetActive (false);
		}

		if (button.name == "LevelSelect") {
			main.SetActive (false);
			levelselect.SetActive (true);
		}

		if (button.tag == "Tile") {
			SceneManager.LoadScene (button.name);
		}
	}
}
