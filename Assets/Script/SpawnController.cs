using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
    
    public Rigidbody2D characters;
    public int spawnEvery = 5;

    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", spawnEvery, spawnEvery);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Spawn()
    {

          Rigidbody2D c = (Rigidbody2D)Instantiate(characters, transform.position, transform.rotation);
    }
}
