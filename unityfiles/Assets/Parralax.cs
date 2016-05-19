using UnityEngine;
using System.Collections;

public class Parralax : MonoBehaviour {

	public Transform[] Backgrounds;
	private float[] ParralaxScales;

	public float smoothing = 1F;

	private Transform cam;
	private Vector3 previouscampos;

	void Awake(){
		cam = Camera.main.transform;
	}


	// Use this for initialization
	void Start () {
		previouscampos = cam.position;

		ParralaxScales = new float[Backgrounds.Length];

		for (int i = 0; i < Backgrounds.Length; i++) {

			ParralaxScales [i] = Backgrounds [i].position.z *-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Backgrounds.Length; i++) {
			
			float parralax = (previouscampos.x - cam.position.x) * ParralaxScales [i];

			float backgroundtargetpoxx = Backgrounds [i].position.x + parralax;

			Vector3 backgroundtargetpos = new Vector3 (backgroundtargetpoxx, Backgrounds [i].position.y, Backgrounds [i].position.z);

			Backgrounds [i].position = Vector3.Lerp (Backgrounds [i].position, backgroundtargetpos, smoothing * Time.deltaTime);
		}

		previouscampos = cam.position;
	}
}
