using UnityEngine;
using System.Collections;

public class CrackedEarth : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.transform.tag == "Rex") {

			if (col.transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Atk1")) {
				this.gameObject.SetActive (false);
			}
		}

	}
}
