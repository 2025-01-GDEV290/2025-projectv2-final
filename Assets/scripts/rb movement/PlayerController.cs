using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1f;
    public float jumpHeight = 5f;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;

    public GliderRB glidingScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (glidingScript != null)

        {
            glidingScript.enabled = false;
        }
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

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Sprint check
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        Vector3 velocity = move * currentSpeed;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        
        if (isGrounded && Mathf.Abs(rb.velocity.y) < 0.01f && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

}