using UnityEngine;
using System.Collections;

public class BloodStairManager : MonoBehaviour {
    public string pyramide;
    public ScoreManager score;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (pyramide == "left") {
            this.transform.localScale = new Vector3(transform.localScale.x, score.Score[0]*0.06f,transform.localScale.z);

        }
        else
        {
            this.transform.localScale = new Vector2(0, score.Score[1]);
        }
	}
}
