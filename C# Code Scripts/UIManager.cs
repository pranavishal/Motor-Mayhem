using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aSource;
    public AudioClip explosion;
    public AudioClip gasCollection;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;    
    }
    void Start()
    { 
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplosionSounds()
    {
        aSource.PlayOneShot(explosion, 0.2f);
    }

    public void GasCollection()
    {
        aSource.PlayOneShot(gasCollection);
    }
}
