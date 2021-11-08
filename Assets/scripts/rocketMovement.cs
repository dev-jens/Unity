using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketMovement : MonoBehaviour
{
    [SerializeField] float thrusterForce = 1000f;
    [SerializeField] float tiltAngle = 100f;

    private bool power = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
    
        power = Input.GetKey(KeyCode.Space);



        if (!Mathf.Approximately(tiltAroundZ, 0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, tiltAroundZ * Time.deltaTime));
        }
        rb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (power)
        {
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
    }

   
}

