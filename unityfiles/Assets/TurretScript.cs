using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TurretScript : MonoBehaviour {


    public Transform target;

    public int pooledamount = 5;
    public float firingtime;

    List<GameObject> bullets;

    public GameObject bullet;

	// Use this for initialization
	void Start () {
        bullets = new List<GameObject>();
        for(int i = 0; i < pooledamount; i++)
        {
            GameObject obj = (GameObject)Instantiate(bullet);
            bullets.Add(obj);
            obj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            target = col.transform;
            InvokeRepeating("Fire", firingtime, firingtime);
        }
       

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            target = null;
            CancelInvoke();
        }
       
        
    }


    void Fire()
    {
      //  Debug.Log("Repeating");
        for(int i = 0; i < bullets.Count; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                bullets[i].GetComponent<TrailRenderer>().enabled = true;
                break;
            }

        }

    }
}
