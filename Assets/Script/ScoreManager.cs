using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int [] Score=new int [2];


	// Use this for initialization
	void Start () {
        Score[0] = 1;
        Score[1] = 1;
	}
	
    public void addScore(int pyramide, int value)
    {
        Score[pyramide] += value;
    }


    // Update is called once per frame
    void Update () {
        if (Score[0] > 100) {
            Win(0);
        }
        else if (Score[1] > 100)
        {
            Win(1);
        }
	}

    void Win (int player)
    {
        string str = "P" + player + "W";
        var win = this.transform.Find(str);
        win.gameObject.SetActive(true);
      
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

        finish();
    }

    IEnumerable finish()
    {
        yield return new WaitForSeconds(20);  // or however long you want it to wait
    }
}
