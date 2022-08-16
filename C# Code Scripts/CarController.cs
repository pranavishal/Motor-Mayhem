using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class CarController : MonoBehaviour
{
    // A Rigidbody is a component that can be added to objects in order to give them physics properties (such as velocity, gravity)
    [SerializeField] public Rigidbody rb;
    // This was part of the joystick pack
    [SerializeField] private FixedJoystick joystick;
    // how fast the car will move
    [SerializeField] private float moveSpeed = 25f;
    //the acceleration
    [SerializeField] private float accelerationIncrease = 0.01f;

    [SerializeField] private float turning = 200f;
    public GameObject exhaustSmoke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (GameManager.instance.start)
        {
            //increase the speed (acceleration)
            moveSpeed += accelerationIncrease;
            //.velocity is a component of any rigidbody which determines its velocity. A velocity is a vector in R^3
            rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                exhaustSmoke.SetActive(true);
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }

            else if (joystick.Horizontal == 0 || joystick.Vertical == 0) 
            { 
                exhaustSmoke.SetActive(false);
                moveSpeed = 25;
            }
        } 
      
    


        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Border")
        {
            this.gameObject.SetActive(false);
            GameManager.instance.DestroyAnimation(this.gameObject.transform.position);
            GameManager.instance.gameOn = false;
            Debug.Log("Got Here");
        }
    }



}

