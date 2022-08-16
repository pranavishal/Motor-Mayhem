using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerCurrentPosition;
    private Vector3 direction;
    public float enemySpeed;
    public GameObject truck;
    public GameObject exhaustSmoke;
    public GameObject model;
    GameObject playerModel;
    private float enemySpeedScaler = 0.003f;
    public static EnemyController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerModel = player.transform.GetChild(0).gameObject;
        playerCurrentPosition = playerModel.transform.position;
        direction = transform.position - playerCurrentPosition;
        truck.transform.LookAt(playerCurrentPosition);
        truck.transform.Rotate(-90f, 0f, 0f);
        
        direction /= 2;
        
        exhaustSmoke.SetActive(true);
         
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.MoveTowards(transform.position, playerCurrentPosition, enemySpeed * Time.deltaTime);  
        transform.Translate(-direction.x * enemySpeedScaler * enemySpeed, 0f, -direction.z * enemySpeedScaler * enemySpeed);
  
    }

    public Vector3 ModelPosition()
    {
        return model.transform.position;
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {           
            GameManager.instance.DestroyAnimation(model.transform.position);
            GameManager.instance.DestroyAnimation(other.gameObject.transform.position);
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
            GameManager.instance.gameOn = false;
            Debug.Log("Got Here");
            
           
        }

        if (other.gameObject.tag == "Border")
        {
            GameManager.instance.DestroyAnimation(model.transform.position); 
            Destroy(this.gameObject);
            
        }
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.DestroyAnimation(model.transform.position);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }


    }

    public void enemySpeedEnhancer()
    {
        enemySpeedScaler += 0.001f;
    }
}  
