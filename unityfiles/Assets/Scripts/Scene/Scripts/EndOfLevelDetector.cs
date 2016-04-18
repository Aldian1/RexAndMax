using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndOfLevelDetector : MonoBehaviour {

	public int nextleveltoload;

	public GameObject[] stars;

    public bool maxpresent;
    public bool rexpresent;

	void OnTriggerEnter2D(Collider2D col)
	{


        if(col.transform.tag == "Player")
            {
            maxpresent = true;
        }

        if (col.transform.tag == "Rex")
        {
            rexpresent = true;
        }

        if (maxpresent && rexpresent)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelController>().GO();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            maxpresent = false;
        }

        if (col.transform.tag == "Rex")
        {
            rexpresent = false;
        }

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
