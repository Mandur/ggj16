using UnityEngine;
using System.Collections;

public class EnvironmentManager : MonoBehaviour {

    private float CondorTimer=3;
    public GameObject Condor;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        CondorTimer -= Time.deltaTime;
        Spawn();
        
    }

    private void Spawn()
    {
        if (CondorTimer < 0)
        {
            CondorTimer = Random.Range(1, 10);
            GameObject created= Instantiate(Condor);
            if (Random.Range(0, 2) == 0)
            {
                created.transform.position = new Vector2(-3.5f,Random.Range(0, 1f));
                created.GetComponent<FlyingShitScript>().speed = Random.Range(0.5f, 2);
            }
            else
            {
                created.transform.position = new Vector2(3.5f, Random.Range(0, 1f));
                created.transform.rotation = Quaternion.Euler(0, 180, 0);
                created.GetComponent<FlyingShitScript>().speed = Random.Range(-0.5f, -2);
            }
        }
    }
}
