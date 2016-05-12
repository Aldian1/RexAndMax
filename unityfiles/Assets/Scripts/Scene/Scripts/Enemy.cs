using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public enum EnemyType
    {
        mailbox = 0,
        flying = 1,
    };

    public EnemyType Enemy_Type;

    public float speed;

    public GameObject smokecloud, scoreobject_;

    public bool incombat;

    private Animator rex;

    

    // Use this for initialization
    void Start() {
       scoreobject_ = GameObject.FindGameObjectWithTag("ScoreEffect");

        if (Enemy_Type == EnemyType.mailbox)
        {

            StartCoroutine("Refresh");
        }
        if (Enemy_Type == EnemyType.flying)
        {
            StartCoroutine("Refresh");

        }
    }

    void Update()
    {
        if (Enemy_Type == EnemyType.mailbox)
        {
			if (!incombat) {
				if (transform.localScale.x == .5F) {
					transform.Translate (-transform.right * Time.deltaTime * speed);
				} else {
					transform.Translate (transform.right * Time.deltaTime * speed);
				}
			}
        }
        if (Enemy_Type == EnemyType.flying)
        {
            if (transform.eulerAngles.y < 180)
            {
                transform.Translate(-transform.up * Time.deltaTime * speed);
            }
            if (transform.eulerAngles.y >= 180)
            {
                transform.Translate(transform.up * Time.deltaTime * speed);
            }


        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        if(col.transform.tag == "Rex")
        {
            incombat = true;
            InvokeRepeating("Combat",0,.35F);
            rex = col.gameObject.GetComponent<Animator>();
            StopCoroutine("Refresh");
        }
        if (col.gameObject.tag == "Player")
        {

            Vector3 contactPoint = col.contacts[0].point;
            //   bool left = contactPoint.x < center.x;
            float x = contactPoint.x -= transform.position.x;
          //  Debug.Log(x);
            if (x < -1.7F || x > 1.7F)
            {

                //if we land on top
                col.gameObject.GetComponent<Player_Controller>().UpdateHealth(.2F);

            }
            else
            {
                //if we land on bottom
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);

                Effect(smokecloud);
            }
        }
    }



    IEnumerator Refresh()
    {
        yield return new WaitForSeconds(2);
        //transform.Rotate(0, +180, 0);
		if (transform.localScale.x == .5F) {

			transform.localScale = new Vector3(-.5F,.5F,.5F);
		} else {
			transform.localScale = new Vector3(.5F,.5F,.5F);
		}

        StartCoroutine("Refresh");
    }


    void Effect(GameObject effect)
    {
        if(effect == smokecloud)
        {
            scoreobject_.SetActive(true);
            scoreobject_.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 3, transform.position.z);
            scoreobject_.GetComponent<EffectControllerTwo>().enabled = true;

            smokecloud.transform.position = this.transform.position;
            smokecloud.SetActive(true);
            smokecloud.GetComponent<EffectController>().enabled = true;
            this.gameObject.SetActive(false);

        }

       
        
    }

    public void Combat()
    {
      if(rex.GetCurrentAnimatorStateInfo(0).IsName("Atk1"))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            return;
        }
        if (rex.GetCurrentAnimatorStateInfo(0).IsName("Atk2"))
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
            return;
        }
        if (rex.GetCurrentAnimatorStateInfo(0).IsName("Atk3"))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);
            Effect(smokecloud);
            return;
        }

    }
}
