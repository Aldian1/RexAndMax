using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StarStorer : MonoBehaviour {



	public List<GameObject> stars = new List<GameObject>();

	public Sprite highlighted;

	public Sprite unhighlighted;

	// Use this for initialization
	void Start () {
		for( int i = 0; i < gameObject.transform.childCount; i++) {
			stars.Add(gameObject.transform.GetChild(i).gameObject);
		}

		if (PlayerPrefs.HasKey (this.name)) {
			Debug.Log ("Key already present");

			if (PlayerPrefs.GetFloat (this.name) == 1) {
				stars [0].GetComponent<Image> ().sprite = highlighted;
			}
			if (PlayerPrefs.GetFloat (this.name) == 2) {
				stars [0].GetComponent<Image> ().sprite = highlighted;
				stars [1].GetComponent<Image> ().sprite = highlighted;
			}
			if (PlayerPrefs.GetFloat (this.name) == 3) {
				stars [0].GetComponent<Image> ().sprite = highlighted;
				stars [1].GetComponent<Image> ().sprite = highlighted;
				stars [2].GetComponent<Image> ().sprite = highlighted;
			}

		} else {
			Debug.Log ("Key not present so we're making one");
			PlayerPrefs.SetFloat (this.name, 0);
			PlayerPrefs.Save();
			
		}
	}
}
