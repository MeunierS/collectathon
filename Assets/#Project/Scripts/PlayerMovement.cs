using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction move;
    //private InputAction jump;
    [SerializeField] private float speed;
    //[SerializeField] WalkingSounds walkingSounds;
    private CharacterController characterController;
    private Camera myCamera;
    private Vector3 forward, right;
    public bool moving { get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
        //jump = playerInput.actions["Jump"];
        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        forward = myCamera.transform.forward;
        right = myCamera.transform.right;
        //forward.y = 0;
        forward = Vector3.ProjectOnPlane(forward,Vector3.up).normalized;
        right = Vector3.ProjectOnPlane(right, Vector3.up).normalized;

        Vector2 movement = move.ReadValue<Vector2>();
        // Vector2 test = new Vector2(0,0);
        // if (movement != test){
        //     walkingSounds.PlayFootstep();
        //     foreach (AudioSource source in GetComponentsInChildren<AudioSource>())
        //     {
        //         if(source.name == "Walking"){
        //             source.PlayFootstep();
        //         }
        //     }
        // }
        moving = movement != Vector2.zero;
        Vector3 finalMovement = movement.x * right + movement.y * forward;
        
        //characterController.Move(new Vector3(movement.x, 0, movement.y) * Time.deltaTime * speed);
        characterController.SimpleMove(finalMovement * speed);
    }
    void OnControllerColliderHit(ControllerColliderHit hit){
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb is null) return;
        rb.velocity = hit.moveDirection;
    }
}
