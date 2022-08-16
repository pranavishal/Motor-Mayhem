using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreBoard;
    public Text highScore;
   // public GameO
    public static int theScore;
    public static ScoreManager instance;
    public GameObject highScoreText;
    public static int deathCount;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.SetActive(true);
        highScoreText.SetActive(true);
        highScore.enabled = true;
        theScore = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.GetComponent<Text>().text = "Score: " + theScore; 
        
        if (theScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", theScore);
            highScore.text = theScore.ToString();
        }

    }


    public void EndGame()
    {
        //scoreBoard.SetActive(false);
        //highScore.enabled = false;
        //highScoreText.SetActive(false);
    }
    public void DeathIncrementer()
    {
        deathCount++;
        PlayerPrefs.SetInt("deaths", deathCount);
    }

   

    
}


