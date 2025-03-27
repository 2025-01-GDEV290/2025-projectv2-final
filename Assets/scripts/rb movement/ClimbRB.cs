using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbRB : MonoBehaviour
{
    public float climbSpeed = 3f;
    [SerializeField]
    private bool isClimbing = false;
    private bool nearLadder = false;
    private Rigidbody rb;
    private Vector3 originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
    }

    void Update()
    {
        if (isClimbing)
        {
            Debug.Log("I am Climbing!" + Time.time);

            Physics.gravity = Vector3.zero;

            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(rb.velocity.x, verticalInput * climbSpeed, rb.velocity.z);
        }
        else
        {

            Physics.gravity = originalGravity;
        }



    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.CompareTag("Ladder"))
        {
            Debug.Log("I'm near the LADDER");
            isClimbing = true;
            nearLadder = true;
        }

        if (nearLadder && Input.GetButton("Climb"))
        {
            Debug.Log("Climb Button Recognized in OnTriggerEnter");
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            nearLadder = false;
            isClimbing = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (nearLadder && Input.GetButton("Climb"))
        {
            Debug.Log("Climb Button Recognized");
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
    }
}
