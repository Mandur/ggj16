using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour
{

    private bool isLaunching = false;
    public Rigidbody2D Bullet;
    private int power = 0;
    //private bool selected = false;
    public ScoreManager score;
    public int side = 0;

    public float selectionInterval = .01f;
    private float selectionTimer = 0;
    public GameObject target;


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
            CheckSelection();
        }
        UpdatePosition();
    }

    /// <summary>
    /// Check if launch
    /// </summary>
    private void CheckLaunch()
    {
       
        if (Input.GetButtonDown("j" + side + "Fire1"))
        {
            this.isLaunching = true;

        }
    }

    /// <summary>
    /// Set the power at which the launcher launch the bullet
    /// </summary>
    private void LauncherPower()
    {
        if (Input.GetButton("j" + side + "Fire1"))
        {
            this.power += 1;
            this.transform.localScale += new Vector3(0.005f, 0.005f);
        }

        if (Input.GetButtonUp("j" + side + "Fire1"))
        {
            target.GetComponent<Rigidbody2D>().velocity = this.transform.right * this.power * 0.1f;
            target.GetComponent<MoveController>().grounded = false;
            FindACharToPoint();
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
        var angle = Mathf.Atan2(Input.GetAxis("j" + side + "Vertical"), Input.GetAxis("j" + side + "Horizontal")) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckSelection()
    {
        var input = Input.GetAxis("j" + side + "Horizontal");
        Debug.Log("CheckSelection()" + input + " * " + selectionTimer + "*" + Time.deltaTime);
        selectionTimer -= Time.deltaTime;
        if (Mathf.Abs(input) > 0.6 && selectionTimer <= 0)
        {
            FindNextCharToPoint(Mathf.Sign(input));
        }

        if (Mathf.Abs(input) < 0.4)
        {
            selectionTimer = 0;
        }

    }
    private void UpdatePosition()
    {
        //Debug.Log(target + "*"+side);
        if (target == null)
        {
            FindACharToPoint();
        }

        if (target != null)
        {
            transform.position = target.transform.position + new Vector3(0, 0.55f);
        }
    }
    private void FindACharToPoint()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject c in objs)
        {
            if(c.GetComponent<MoveController>()!=null)
            if (c.GetComponent<MoveController>().side == this.side
                  && c.GetComponent<MoveController>().grounded)
            {
                target = c;
                return;
            }
        }
    }
    private void FindNextCharToPoint(float direction)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        GameObject next = null;
        float maxDist = 10000000f;
        foreach (GameObject c in objs)
        {
            //Debug.Log(c+"*"+c.GetComponent<MoveController>());
            if(c.GetComponent<MoveController>()!=null)
            if (c.GetComponent<MoveController>().side == side
                && c.GetComponent<MoveController>().grounded
                && ((direction < 0 && target.transform.position.x > c.transform.position.x)
                || (direction > 0 && target.transform.position.x < c.transform.position.x)))
            {
                float dist = Mathf.Abs(target.transform.position.x - c.transform.position.x);
                if (dist < maxDist)
                {
                    maxDist = dist;
                    next = c;
                    selectionTimer = selectionInterval;
                }
            }
        }
        if (next != null)
        {
            target = next;
        }
    }

}
