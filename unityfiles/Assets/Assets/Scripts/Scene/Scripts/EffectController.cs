using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

    private Animator thisanimator;
   

	// Use this for initialization
	void Start () {


    thisanimator = GetComponent<Animator>();
           
     
        
	}

    void Update()
    {
        if (thisanimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
                this.gameObject.SetActive(false);
                this.enabled = false;
        }
      
     

       
        
    }
}
