using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xpos = 1.5f;
    Rigidbody rb;
    public float jumpforce = 300f;
    public float forwardForce = 1000f;
    public float velocity = 500f;
     public Transform Groundcheck = null;
     public bool isgrounded = false;
     public LayerMask groundmask;
     public float checkradius = 0.2f;
     float downspeed = 0f;
    GameManager gm;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    public void Movement(string command)
    {
        command = command.ToLower();
       
        switch (command)
        {
          case "right":
                transform.position = new Vector3(transform.position.x + xpos, transform.position.y, transform.position.z);
                break;
          
            case "left":
                transform.position = new Vector3(transform.position.x - xpos, transform.position.y, transform.position.z);
                break;
           
            case "jump":
                 rb.AddForce(Vector3.up * jumpforce);
              /* if(isgrounded)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * jumpforce, rb.velocity.z);
                    downspeed = 20f;
                }*/
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //  rb.velocity = transform.forward * forwardForce + transform.up * downspeed;
          isgrounded = Physics.CheckSphere(Groundcheck.position, checkradius, groundmask);
         if(!isgrounded)
         {
             downspeed = -2f;
            // rb.velocity = new Vector3(rb.velocity.x, -9.8f * jumpforce, rb.velocity.z);
         }
        if (rb.position.y < -1.00f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void Update()
    {
       
      //  isgrounded = Physics.CheckSphere(Groundcheck.position, checkradius, groundmask);
       /* if(!isgrounded)
        {
            downspeed = -2f;
           // rb.velocity = new Vector3(rb.velocity.x, -9.8f * jumpforce, rb.velocity.z);
        }*/

    }
}
