using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    private float speed = 0.3f;
    public int side = 0;
    public bool grounded = true;
    public bool disabled = false;
    public bool onPyramid = false;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            if (onPyramid)
            {
                int direction = side == 0 ? 1 : -1;
                GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, speed);
            }

            else
            {
                int direction = side == 0 ? 1 : -1;
                GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, 0);
            }
        }

        // Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet, this.transform.position, this.transform.rotation);
        // bullet.velocity = this.transform.right * this.power;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pyramide")
        {
            if (grounded == true)
                onPyramid = true;
            else
                Destroy(this);
        }
        

        if (coll.gameObject.tag == "Ground" && !grounded)
        {
            Destroy(coll.gameObject);
            coll.gameObject.GetComponent<Animator>().SetBool("Exploding", true);
        }
        if (grounded && coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<MoveController>().side != side)
        {
            Destroy(coll.gameObject,1);
            coll.gameObject.GetComponent<Animator>().SetBool("Exploding", true);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Priest" && !this.disabled)
        {
            ScoreManager sm = Object.FindObjectOfType<ScoreManager>();
            if (this.name.Contains("gros"))
            {
                sm.addScore(side, 15);
            }
            else if (this.name.Contains("skin"))
            {
                sm.addScore(side, 3);
            }
            else sm.addScore(side, 9);
            this.gameObject.GetComponent<Animator>().SetBool("Exploding", true);
            Destroy(this.gameObject,1);
        }

        if (disabled&&coll.gameObject.tag == "Player")
        {
            if (coll.gameObject.GetComponent<MoveController>().side != this.side)
            {
                coll.gameObject.GetComponent<Animator>().SetBool("Exploding",true);
                Destroy(coll.gameObject,1);   
            }
          
        }
        else if (disabled &&!(coll.gameObject.tag == "Priest"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Exploding", true);
            Destroy(this,1);
            
        }

        //sm.

        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }

    public void CheckSide()
    {
        if (transform.position.x < 0)
        {
            side = 0;
            GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            side = 1;
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }

    }
}
