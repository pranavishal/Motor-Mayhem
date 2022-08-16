using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [SerializeField] private int score;
    public GameObject explosion;
    public GameObject gameOverText;

    private float timerStart = 4f;
    private float currentTimer;

    public bool gameOn;
    public bool timerActive;
    public TMP_Text go;
    [SerializeField] TMP_Text countDownText;
    public bool start;
    public GameObject retryButton;
    public GameObject quitButton;

    public GameObject soundButton;

    public AudioSource source;
    public AudioClip button;
    public int adNumber = 0;
    //public bool gameStart;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        retryButton.SetActive(false);
        quitButton.SetActive(false);
        soundButton.SetActive(false);
        start = false;
        go.enabled = false;
        countDownText.enabled = true;
        timerActive = true; 
        currentTimer = timerStart;

        gameOverText.SetActive(false); 
        gameOn = true;
    }

    // Update is called once per frame 
    void Update()
    {
        if (timerActive)
        {
            if(currentTimer == 1)
            {
                timerActive = false;
                Time.timeScale = 1f;
                countDownText.enabled = false;
                StartCoroutine(GoText());
                start = true;
            }
            currentTimer -= 1 * Time.deltaTime;
            

            if(currentTimer <= 1)
            {
                currentTimer = 1;
               
            } 
            else
            {
                countDownText.text = currentTimer.ToString("0");
            }

        }
        else if (!gameOn)
        {
            EndGame();
        }
    }
    public void IncrementScore()  
    {
        ScoreManager.theScore ++;
        score ++;
        UIManager.instance.GasCollection();

        if(ScoreManager.theScore == 2)
        {
            Generator.instance.generationRate = 0.45f;
            Generator.instance.NewInvoke(Generator.instance.generationRate);
        }

        else if(ScoreManager.theScore == 5)
        {
            Generator.instance.generationRate = 0.4f;
            Generator.instance.NewInvoke(Generator.instance.generationRate);
            EnemyController.instance.enemySpeedEnhancer();
        }

        else if(ScoreManager.theScore == 10)
        {
            Generator.instance.generationRate = 0.3f;
            Generator.instance.NewInvoke(Generator.instance.generationRate);
            EnemyController.instance.enemySpeedEnhancer();
        }

        else if(ScoreManager.theScore == 15)
        {
            Generator.instance.generationRate = 0.25f;
            Generator.instance.NewInvoke(Generator.instance.generationRate);
           // EnemyController.instance.enemySpeedEnhancer();
        }

        else if(ScoreManager.theScore == 25)
        {
            Generator.instance.generationRate = 0.2f;
            Generator.instance.NewInvoke(Generator.instance.generationRate);
            EnemyController.instance.enemySpeedEnhancer();
        }

    }

    public void DestroyAnimation(Vector3 location)
    {
        var effect = Instantiate(explosion, location, Quaternion.identity);
        UIManager.instance.ExplosionSounds();
        Destroy(effect, 5);
    }

    public void EndGame()
    {
        Generator.instance.CancelGeneration();
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
        quitButton.SetActive(true); 
        soundButton.SetActive(true);
        ScoreManager.instance.EndGame();
       
        //StartCoroutine(Freeze(8));
    }
    
 
   IEnumerator Timer(int secs)
    {
        yield return new WaitForSeconds(secs);
        Time.timeScale = 0f;
    }

    IEnumerator GoText()
    {
        go.enabled = true;
        yield return new WaitForSeconds(1);
        go.enabled = false;
    }

    public void RestartButton()
    {
        ScoreManager.instance.DeathIncrementer();
        source.PlayOneShot(button);
        SceneManager.LoadScene("MainGame");
        //ScoreManager.EndGame();
       // ScoreManager.theScore = 0;
    }

    public void QuitButton()
    {
        ScoreManager.instance.DeathIncrementer();
        source.PlayOneShot(button);
        SceneManager.LoadScene("IntroScene");
    }
 
}
