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

            if (transform.eulerAngles.y < 180)
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
            }
            if (transform.eulerAngles.y >= 180)
            {
                transform.Translate(transform.right * Time.deltaTime * speed);
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

        if (col.gameObject.tag == "Player")
        {

            Vector3 contactPoint = col.contacts[0].point;
            //   bool left = contactPoint.x < center.x;
            float x = contactPoint.x -= transform.position.x;
          //  Debug.Log(x);
            if (x < -1F || x > 1F)
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
        transform.Rotate(0, +180, 0);
        StartCoroutine("Refresh");
    }

    void Fireballs()
    {
        // GameObject fireball = Instantiate(fireball_, transform.position, Quaternion.identity) as GameObject;

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
}
