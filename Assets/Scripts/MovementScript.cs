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
    [SerializeField] MenuManager menuManager;
    private bool isCrafting;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isCrafting = menuManager.isCMenuActive;
    }

    void FixedUpdate()
    {
        if (!isCrafting)
        {
            InputManager();
            PlayerMovement();
        }

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
