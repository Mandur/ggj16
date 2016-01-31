using UnityEngine;
using System.Collections;

public class pyramidControler : MonoBehaviour {

	public int side;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.gameObject.GetComponent<MoveController>().side != this.side)

		{

			Destroy (coll.gameObject);


		}
}
}