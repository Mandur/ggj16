using UnityEngine;
using System.Collections;

public class BloodStairManager : MonoBehaviour {
    public int pyramide;
    public ScoreManager score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
            this.transform.localScale = new Vector3(transform.localScale.x, score.Score[pyramide]*0.06f,transform.localScale.z);

    }
}
