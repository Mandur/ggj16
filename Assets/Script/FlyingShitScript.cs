using UnityEngine;
using System.Collections;

public class FlyingShitScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
	}
	
	// Update is called once per frame
	void Update () {
	       
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Poulet")
        {
            this.transform.Rotate(new Vector3(0,0,-30));
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
