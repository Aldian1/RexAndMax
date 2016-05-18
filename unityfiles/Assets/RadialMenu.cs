using UnityEngine;
using System.Collections;

public class RadialMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnEnable()
    {
        Debug.Log("Play");
        GetComponent<Animation>().Play();
    }
}
