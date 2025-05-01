using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbLukeTrigger : MonoBehaviour
{
    public class WallClimb : MonoBehaviour
    {
        private Rigidbody rb;
        public float climbSpeed = 3f;
        public float stickToWallForce = 2f;

        private bool isInClimbZone = false;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (isInClimbZone && Input.GetKey(KeyCode.Space))
            {
                rb.useGravity = false;

                Vector3 upwardMovement = transform.up * climbSpeed * Time.deltaTime;
                Vector3 forwardMovement = transform.forward * stickToWallForce * Time.deltaTime;

                rb.MovePosition(transform.position + upwardMovement + forwardMovement);
            }
            else
            {
                rb.useGravity = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StartClimbingTrigger"))
            {
                isInClimbZone = true;
            }
            if (other.CompareTag("StopClimbingTrigger"))
            {
                isInClimbZone = false;
            }
        }


    }
}
