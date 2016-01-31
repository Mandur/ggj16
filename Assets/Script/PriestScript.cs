using UnityEngine;
using System.Collections;

public class PriestScript : MonoBehaviour {
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.tag == "Player" && coll.gameObject.GetComponent<MoveController>().disabled == false)
        {
            animator.SetTrigger("SacrificeTrigger");
			GetComponent<AudioSource>().Play();
        }
   

    }
}
