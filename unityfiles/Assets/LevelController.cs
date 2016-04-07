using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {


	public float score;
	public int lives = 3;
	public GameObject endoflevelMarker;

	public GameObject endoflevelscreen;

	// Use this for initialization
	void Start () {
	
	}

	public void GO()
	{
		endoflevelscreen.SetActive (true);
	}
}
