using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{

    public List<GameObject> characters;
    public int spawnEvery = 1;
    public int side = 1;

    // Use this for initialization
    void Start()
    {
        Spawn();
        InvokeRepeating("Spawn", spawnEvery, spawnEvery);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {

        GameObject c = (GameObject)Instantiate(characters[Mathf.FloorToInt(Random.value*characters.Count)], transform.position, transform.rotation);
        //c.GetComponent<MoveController>().side = this.side;
        c.GetComponent<MoveController>().CheckSide();
        if (c.GetComponent<MoveController>().side == 1)
        {
            c.layer = 9;
        }
    }
}
