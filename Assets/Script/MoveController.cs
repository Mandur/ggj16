using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    public float speed = 0.5f;
    public int side = 0;
    public bool grounded = true;
    public bool onPyramid = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        // Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet, this.transform.position, this.transform.rotation);
        // bullet.velocity = this.transform.right * this.power;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pyramide")
        {
            onPyramid = true;
        }
        else
        {
            onPyramid=false;
        }

        if (coll.gameObject.tag == "Ground" && !grounded)
        {
            Destroy(gameObject);
        }
        if (grounded && coll.gameObject.tag == "Player" && coll.gameObject.GetComponent<MoveController>().side != side)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Priest" && this.grounded)
        {
            ScoreManager sm = Object.FindObjectOfType<ScoreManager>();
            sm.addScore(side, 1);
            Destroy(gameObject);
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
