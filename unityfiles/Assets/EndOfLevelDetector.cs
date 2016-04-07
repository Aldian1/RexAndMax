using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndOfLevelDetector : MonoBehaviour {

	public int nextleveltoload;

	public GameObject[] stars;
	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LevelController>().GO();
	}


	public void ButtonOption(Button button){
		if (button.name == "MainMenu") {
			SceneManager.LoadScene (0);
		}

		if (button.name == "NextLevel") {
			SceneManager.LoadScene (nextleveltoload);


		}
	}
}
