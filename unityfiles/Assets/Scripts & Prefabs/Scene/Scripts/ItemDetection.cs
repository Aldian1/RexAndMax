using UnityEngine;
using System.Collections;

public class ItemDetection : MonoBehaviour {

    public bool MaxOnly;
    public bool RexOnly;
    public bool RexOrMax;

    public enum Items
    {
        BalloonPowerup = 0,
        MaxSligshotAmmo =1,
        
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
        if(col.transform.tag == "Rex" && RexOnly == true)
        {
            col.GetComponent<Player_Controller>().GetItem(UsableItem);
            this.gameObject.SetActive(false);
            return;
        }
        if (col.transform.tag == "Player" && MaxOnly == true)
        {
            col.GetComponent<Player_Controller>().GetItem(UsableItem);
            this.gameObject.SetActive(false);
            return;
        }

        if (col.transform.tag == "Player" || col.transform.tag == "Rex" )
        {
            if (RexOrMax == true)
            {
                col.GetComponent<Player_Controller>().GetItem(UsableItem);
                this.gameObject.SetActive(false);
                return;
            }
        }
    }
}
