using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void OpenWebsite()
	{
		Application.OpenURL("http://maxandrex.com/");
	}
}
