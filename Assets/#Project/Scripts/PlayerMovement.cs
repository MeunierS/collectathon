using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;
    private InputAction jump;
    [SerializeField] private float speed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        jump = playerInput.actions["Jump"];
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = move.ReadValue<Vector2>();
        //characterController.Move(new Vector3(movement.x, 0, movement.y) * Time.deltaTime * speed);
        characterController.SimpleMove(new Vector3(movement.x, 0, movement.y) * speed);
    }
    void OnControllerColliderHit(ControllerColliderHit hit){
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb is null) return;
        rb.velocity = hit.moveDirection;
    }
}
