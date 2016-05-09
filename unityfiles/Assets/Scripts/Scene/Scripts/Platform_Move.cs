using UnityEngine;
using System.Collections;

public class Platform_Move : MonoBehaviour {

	private Vector3 target, orignalposition;

	public float smoothTime = 0.3F;
	public float PlusYValue;


	private Vector3 velocity = Vector3.zero;

	private int switcher;

	public bool invert;


	void Start()
	{
		orignalposition = this.transform.position;
		target = new Vector3 (transform.position.x, transform.position.y + PlusYValue, transform.position.z);

		if (invert == true) {
			transform.position = target;
			switcher = 1;
		}
	}

	void Update() {


		switch (switcher) {
		case 0:
			transform.position = Vector3.SmoothDamp (transform.position, target, ref velocity, smoothTime);
			if (Vector3.Distance (transform.position, target) < .2F) {
				switcher = 1;
			}

			break;
		case 1:
			transform.position = Vector3.SmoothDamp (transform.position, orignalposition, ref velocity, smoothTime);
			if (Vector3.Distance (transform.position, orignalposition) < .2F) {
				switcher = 0;
			}
			break;
		}



	}
}
