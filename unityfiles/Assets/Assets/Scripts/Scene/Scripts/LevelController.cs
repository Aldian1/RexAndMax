using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour {


	public float score;
	public int lives = 3;
	public int deathcounter = 0;
	public GameObject endoflevelMarker;

	public GameObject endoflevelscreen,overlay,pausescreen,Radial;

	public GameObject[] stars;

	public Text deaths;

	public Text Score;

	public GameObject max,rex;

	public AudioSource ad;

	// Use this for initialization
	void Start () {
		max = GameObject.FindGameObjectWithTag ("Player");
		rex = GameObject.FindGameObjectWithTag ("Rex");
		ad = GetComponent<AudioSource> ();
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


    public void Pause(bool state)
    {
       if(state == true)
        {
            Time.timeScale = 0;
            overlay.SetActive(false);
            pausescreen.SetActive(true);
        }
        if (state == false)
        {
            overlay.SetActive(true);
            pausescreen.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void buttonstate(Button button)
    {
        if(button.name == "Resume")
        {
            Pause(false);
        }

        if(button.name == "ReportBug")
        {
            Application.OpenURL("https://github.com/Aldian1/RexAndMax/issues/");
        }

        if(button.name == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Time.timeScale = 1;
        }

        if (button.name == "Quit")
        {
            Application.Quit();
        }

        if(button.name == "Radial")
        {
            Time.timeScale = 0;
            overlay.SetActive(false);
            Radial.SetActive(true);
        }

    }

    
}
