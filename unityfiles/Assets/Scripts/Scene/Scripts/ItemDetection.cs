using UnityEngine;
using System.Collections;

public class ItemDetection : MonoBehaviour {



    public enum Items
    {
        BalloonPowerup = 0,
        MaxSligshotAmmo =1,
        Stars = 2,
		GorillaMilk =3,
        
    };

   public Items UsableItem;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.transform.tag == "Player")
        {
           
                col.GetComponent<Player_Controller>().GetItem(UsableItem);
                this.gameObject.SetActive(false);
                return;
    
        }
    }
}
