using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour {

    public GameObject scoreText;
    public int score = 0;
    
    
    // Use this for initialization
	void Start () {
        this.scoreText = GameObject.Find("ScoreText");

        score = 0;
        SetScore();



	}
    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;


        if (yourTag == "SmallStarTag")
        {
            score += 10;
        }
        else if (yourTag == "LargeStarTag")
        {
            score += 100;
        }
        else if (yourTag == "SmallCloudTag" )
        {
            score += 50;
        }
        else if (yourTag ==  "LargeCloudTag")
        {
            score += 200;
        }
  
        SetScore();
    }

    void SetScore()
    {
        this.scoreText.GetComponent<Text>().text= string.Format("Score:{0}", score);
    }



    // Update is called once per frame
    void Update () {
        
	}
}
