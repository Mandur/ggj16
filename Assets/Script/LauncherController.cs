using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour {

    private bool isLaunching = false;
    public Rigidbody2D Bullet;
    private int power = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        LauncherRotation();

        LauncherPower();

    }

    /// <summary>
    /// Set the power at which the launcher launch the bullet
    /// </summary>
    private void LauncherPower()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.isLaunching = true;
        }
        if (Input.GetButton("Fire1"))
        {
            this.power += 1;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet,this.transform.position,this.transform.rotation);
            bullet.velocity =this.transform.right*this.power;
            this.power = 0;
            
        }
    }


    /// <summary>
    /// set the rotation of the launcher
    /// </summary>
    private void LauncherRotation()
    {

        if (Input.GetAxis("Horizontal") !=0)
        {
            this.transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal")));
        }
       
    }
}
