using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
	private float speed = 20.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
	private float forwardInput;
	
    void Update()
    {
        // This is where we get player input
		horizontalInput = Input.GetAxis("Horizontal");
		forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
		transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // We turn the vehicle
		transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
