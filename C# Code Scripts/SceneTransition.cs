using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public AudioSource source;
    public AudioClip button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        source.PlayOneShot(button);
        SceneManager.LoadScene("MainGame");
    }

    public void IntroQuit()
    {
        source.PlayOneShot(button);
        Application.Quit();
    }
}
