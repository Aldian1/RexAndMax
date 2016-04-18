using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	public GameObject HiddenButton, MasterFrame;

    public GameObject[] menuitems;

    public Sprite[] sceneimages;

    public GameObject[] Stars;
	// Use this for initialization
	void Start () {
	
	}
	public void OpenWebsite()
	{
		Application.OpenURL("http://maxandrex.com/");
	}

	public void Nextoverlay(Button button)
	{
		
		if (button.name == "HiddenButton") {
            //StartCoroutine("Fade", button);
            button.transform.FindChild("Text").GetComponent<Text>().CrossFadeAlpha(0, 1, false);
            button.transform.FindChild("MR").GetComponent<Image>().CrossFadeAlpha(0, 1, false);
            StartCoroutine("Disabler", button);
        }

		if (button.tag == "Tile") {
            LoadLevelDetails(button);
		}
	}

   IEnumerator Disabler(Button button)
    {
        yield return new WaitForSeconds(1);
        button.gameObject.SetActive(false);
        if(button.name == "HiddenButton")
        {
            mainmenubuttons();
        }
    }

    void mainmenubuttons()
    {
        foreach (GameObject item in menuitems)
        {
            item.SetActive(true);
        }
        MasterFrame.SetActive(false);
    }

    void LoadLevelDetails(Button button)
    {
        MasterFrame.SetActive(true);
        MasterFrame.transform.FindChild("LN").GetComponent<Text>().text = button.name;

        float t;
        t = PlayerPrefs.GetFloat(button.name);
        if(t == 3)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
            Stars[2].SetActive(true);
        }
        if(t == 2)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(true);
        }
        if(t == 1)
        {
            Stars[0].SetActive(true);
        }
    }
}
