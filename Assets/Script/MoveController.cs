﻿using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{

    public float speed = 0.5f;
    public int direction = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, 0f);

        // Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet, this.transform.position, this.transform.rotation);
        // bullet.velocity = this.transform.right * this.power;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            coll.gameObject.SendMessage("ApplyDamage", 10);

    }
}