using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour {

    private bool isLaunching = false;
    public Rigidbody2D Bullet;
    public float BulletSpeed;
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

    private void LauncherPower()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.isLaunching = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.power += 1;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet,this.transform.position,this.transform.rotation);
            bullet.AddForce(bullet.transform.forward* BulletSpeed);
            
        }
    }

    private void LauncherRotation()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, -1));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, 1));
        }
    }
}
