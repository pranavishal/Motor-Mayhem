using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Camera cam;
    public GameObject[] items;
    public float generationRate = 0.5f;
    public GameObject explosion;

    public static Generator instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 5, generationRate);  
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        
    } 

    public void Generate() 
    {
        const float yVal = -1.21f; 
        const float x_min = -40f;
        const float x_max = 40;
        const float z_min = -25;   
        const float z_max = 50;

        Vector3 enemySpawnPosition = new Vector3(Random.Range(x_min, x_max), yVal, Random.Range(z_min, z_max));

        Vector3 positionToGenerate = cam.WorldToViewportPoint(enemySpawnPosition);
        bool inCameraScope = positionToGenerate.z > 0 && positionToGenerate.x > 0 && positionToGenerate.x < 1 && positionToGenerate.y > 0 && positionToGenerate.y < 1;

        if(!inCameraScope)
        {
            int random = Random.Range(0, 5);
            Debug.Log(random);
            Instantiate(items[random], enemySpawnPosition, Quaternion.identity);  
        }
    }

    public void NewInvoke(float rate)
    {
        CancelInvoke();
        InvokeRepeating("Generate", 1, generationRate);
    }

    public void CancelGeneration()
    {
        CancelInvoke();
    }
}
