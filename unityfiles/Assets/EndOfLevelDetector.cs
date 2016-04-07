using UnityEngine;
using System.Collections;

public class EndOfLevelDetector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<LevelController>().GO();
	}
}
