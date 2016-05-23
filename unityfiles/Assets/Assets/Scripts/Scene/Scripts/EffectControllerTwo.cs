using UnityEngine;
using System.Collections;

public class EffectControllerTwo : MonoBehaviour {

    private Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
	if(!anim.isPlaying)
        {
            gameObject.SetActive(false);
            this.enabled = false;
        }
	}
}
