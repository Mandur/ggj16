using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour
{

    private bool isLaunching = false;
    public Rigidbody2D Bullet;
    private int power = 0;
    private bool selected = false;
    public ScoreManager score;
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        CheckLaunch();

        if (this.isLaunching)
        {
            LauncherRotation();
            LauncherPower();
        }
        else {

        }
    }

    /// <summary>
    /// Check if launch
    /// </summary>
    private void CheckLaunch()
    {


        // pointer.transform.position= new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y + Input.GetAxis("Vertical"),-1);

        if (Input.GetButtonDown("Fire1"))
        {
            this.isLaunching = true;
            
        }
    }

    /// <summary>
    /// Set the power at which the launcher launch the bullet
    /// </summary>
    private void LauncherPower()
    {
        if (Input.GetButton("Fire1"))
        {
            this.power += 1;
            this.transform.localScale += new Vector3(0.005f, 0.005f);
        }

        if (Input.GetButtonUp("Fire1"))
        {

            Rigidbody2D bullet = (Rigidbody2D)Instantiate(Bullet, this.transform.position, this.transform.rotation);
            bullet.velocity = this.transform.right * this.power;
            score.AddScoreLeft(5);
            ResetLauncher();
        }
    }


    /// <summary>
    /// Method to reset the Launcher
    /// </summary>
    private void ResetLauncher()
    {
        this.power = 0;
        this.isLaunching = false;
        this.transform.rotation = Quaternion.Euler(0, 0, 270);
        this.transform.localScale = new Vector3(1, 1);

    }


    /// <summary>
    /// set the rotation of the launcher
    /// </summary>
    private void LauncherRotation()
    {

        //You may have to play around with/switch the y and x
        var angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);


    }


}
