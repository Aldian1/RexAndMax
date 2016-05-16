﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthListener : MonoBehaviour {

    public bool max,rex;

    public GameObject montioring;

    public float currenthealth;
    void Start()
    {
        if (rex)
        {
            montioring = GameObject.FindGameObjectWithTag("Rex");
        }
        if(max)
        {
            montioring = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void updatehealth(float amount)
    {
        currenthealth -= amount;
        GetComponent<Image>().fillAmount = currenthealth;
		if (currenthealth <= 0) {

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
