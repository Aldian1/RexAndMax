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
        GameObject go = GameObject.FindGameObjectWithTag("Rex");
    //    Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

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

            if (transform.localScale.x == .5F)
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(transform.right * Time.deltaTime * speed);

            }
        }
        if (Enemy_Type == EnemyType.flying)
        {
            if (transform.localScale.x == .6F)
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(transform.right * Time.deltaTime * speed);


            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        if (col.transform.tag == "Player")
        {
            col.transform.GetComponent<Player_Controller>().UpdateHealth(.2F);
        }

        if (col.transform.tag == "Rex")
        {
            
            InvokeRepeating("Combat",0,.35F);
            rex = col.gameObject.GetComponent<Animator>();
            StopCoroutine("Refresh");
        }
       
        
    }



    IEnumerator Refresh()
    {
        if (Enemy_Type == EnemyType.mailbox)
        {
            yield return new WaitForSeconds(2);
            //transform.Rotate(0, +180, 0);
            if (transform.localScale.x == .5F)
            {

                transform.localScale = new Vector3(-.5F, .5F, .5F);
            }
            else
            {
                transform.localScale = new Vector3(.5F, .5F, .5F);
            }

            StartCoroutine("Refresh");
        }

        if (Enemy_Type == EnemyType.flying)
        {
            yield return new WaitForSeconds(2);
            //transform.Rotate(0, +180, 0);
            if (transform.localScale.x == .6F)
            {

                transform.localScale = new Vector3(-.6F, .6F, .6F);
            }
            else
            {
                transform.localScale = new Vector3(.6F, .6F, .6F);
            }

            StartCoroutine("Refresh");
        }
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
		if (rex.GetCurrentAnimatorStateInfo (0).IsName ("Atk1") || rex.GetCurrentAnimatorStateInfo(0).IsName("Atk2") || rex.GetCurrentAnimatorStateInfo(0).IsName("Atk3")) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);
			Effect(smokecloud);
			CancelInvoke ("Combat");
			return;
		}
        

    }
}
