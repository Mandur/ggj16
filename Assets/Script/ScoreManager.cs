using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int ScoreLeft=0;
    public int ScoreRight=0;

	// Use this for initialization
	void Start () {
	
	}
	
    public void AddScoreLeft(int score)
    {
        ScoreLeft += score;
    }

    public void AddScoreRight(int score)
    {
        ScoreRight += score;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
