﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignText : MonoBehaviour {

    
    public string TextToDisplay;
	private GameObject SignDeliver;
	// Use this for initialization
	void Start () {

		GameObject go = GameObject.Find ("Overlay");
		SignDeliver = go.transform.FindChild ("ST").gameObject;

	
 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            SignDeliver.SetActive(true);
            SignDeliver.GetComponentInChildren<Text>().text = TextToDisplay;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            SignDeliver.SetActive(false);
            SignDeliver.GetComponentInChildren<Text>().text = TextToDisplay;
        }
    }
}