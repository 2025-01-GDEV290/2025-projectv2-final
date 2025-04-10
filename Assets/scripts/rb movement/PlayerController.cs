using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //Debug.LogFormat("RigidBody {0}  movex:{1}  movez:{2}", rb.name, moveX, moveZ);

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        

        Vector3 velocity = move * moveSpeed;
        

        rb.velocity = new
            Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
   
}