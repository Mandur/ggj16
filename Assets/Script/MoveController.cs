using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    public float speed = 0.5f;
    public int side = 0;
    public bool grounded = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            int direction = side == 0 ? 1 : -1;
            GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, 0f);
        }

        // Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet, this.transform.position, this.transform.rotation);
        // bullet.velocity = this.transform.right * this.power;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Priest")
        {
            Debug.Log(coll.gameObject.tag + "*");
            //Destroy(gameObject);
        }

        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Priest")
        {
            Debug.Log(coll.gameObject.tag + "*");

            ScoreManager sm = Object.FindObjectOfType<ScoreManager>();
            Destroy(gameObject);
        }

        //sm.

        //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
}
