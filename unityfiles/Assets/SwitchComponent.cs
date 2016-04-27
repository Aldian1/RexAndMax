using UnityEngine;
using System.Collections;

public class SwitchComponent : MonoBehaviour {

    public GameObject SwitchActivator;
	// Use this for initialization
	void Start () {
	
	}
	

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.transform.name == "Box")
        {
            SwitchActivator.SetActive(false);
        }

    }
}
