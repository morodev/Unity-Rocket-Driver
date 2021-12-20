using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("Pressed SPACE - Thristing");
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);         
            // rigidBody.AddRelativeForce(0, 1, 0);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Rotating left");
            ApplyRotation(rotationThrust);
            // transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
            // transform.Rotate(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Rotatin right");
            ApplyRotation(-rotationThrust);
            // transform.Rotate(-Vector3.forward * rotationThrust * Time.deltaTime);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}

