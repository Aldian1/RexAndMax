using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour {


	public float score;
	public int lives = 3;
	public int deathcounter = 0;
	public GameObject endoflevelMarker;

	public GameObject endoflevelscreen;

	public GameObject[] stars;

	public Text deaths;

	public Text Score;

	public GameObject max,rex;

	public AudioSource ad;

	public GameObject pauseelements,overlay;

	// Use this for initialization
	void Start () {
		max = GameObject.FindGameObjectWithTag ("Player");
		rex = GameObject.FindGameObjectWithTag ("Rex");
		ad = GetComponent<AudioSource> ();
		overlay = GameObject.Find ("Overlay");
		pauseelements = GameObject.FindGameObjectWithTag("PauseScreen");
	}

	public void GO()
	{



		Score.text = "Score: " + score.ToString();
		deaths.text = "Deaths: " + deaths.ToString ();
		max.SetActive (false);
		rex.SetActive (false);
		if (lives == 3) {
			stars [0].SetActive (true);
			stars [1].SetActive (true);
			stars [2].SetActive (true);
		}

		if (lives == 2) {
			stars [0].SetActive (true);
			stars [1].SetActive (true);
		}

		if (lives == 1) {
			stars [0].SetActive (true);
		
		}
		endoflevelscreen.SetActive (true);
		PlayerPrefs.SetFloat (SceneManager.GetActiveScene().name, lives);
		PlayerPrefs.Save ();
		ad.volume = 0.5F;
	}

	public void PauseScreen(bool stage)
	{
		if (stage == true) {
			Time.timeScale = 0;
			pauseelements.SetActive (true);
			overlay.SetActive (false);
		}
		if (stage == false) {
			Time.timeScale = 1;
			overlay.SetActive (true);
			pauseelements.SetActive (false);
		}
	}

	public void Restart()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		Time.timeScale = 1;
		overlay.SetActive (true);
		pauseelements.SetActive (false);
		
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
