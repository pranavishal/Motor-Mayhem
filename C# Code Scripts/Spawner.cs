using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject objectToSpawn;
    public GameObject nextSpawn;
    public float Radius = 1;
    public int numOfFruits = 5; // placeholder 5 apples
    int items = 5;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfFruits; i++){
            SpawnObjectAtRandom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (items < numOfFruits){
            Vector3 newRandomPos = new Vector3(Random.Range(-47,47),-1.61f, Random.Range(-33,60));
            Instantiate(nextSpawn, newRandomPos, Quaternion.identity);
        }
        // destroy the cube when player makes contact
    }

    public void SpawnObjectAtRandom()
    {
        Vector3 randomPos = new Vector3(Random.Range(-47,47),-1.61f, Random.Range(-33,60));
        Instantiate(objectToSpawn, randomPos, Quaternion.identity);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Play Animation
            Destroy(this.gameObject);
            items -= 1;
        }
    }
}    
