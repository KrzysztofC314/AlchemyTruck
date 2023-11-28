using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveVelocity;
    private float forwardMoveInput;
    private float sidewaysMoveInput;
    private float up_downMoveInput;
    private float velocityX;
    private float velocityY;
    private float velocityZ;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputManager();
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        velocityX = sidewaysMoveInput * moveVelocity;
        velocityZ = forwardMoveInput * moveVelocity;


        rb.velocity = new Vector3(velocityX,0,velocityZ);
    }
    private void InputManager()
    {
        sidewaysMoveInput = Input.GetAxis("Horizontal");
        forwardMoveInput = Input.GetAxis("Vertical");
        Vector3 movementInput = new Vector3(sidewaysMoveInput, 0, forwardMoveInput);
    }
}
