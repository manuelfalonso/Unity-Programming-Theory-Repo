using System;
using UnityEngine;

/// <summary>
/// Third Person Character Controller Class
/// It may be use with Cinemachine
/// Optional: Animation Controller
/// </summary>

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
	private Camera gameCamera;
    private CharacterController controller;
    //private Animator animator;
    private Vector3 playerVelocity;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float fallSpeed = -0.5f;
    private bool isGrounded;

    // gravity = H/2t² -> Use this to change intended behaviour
    // H = height to jump. t = time
    const float GRAVITY_VALUE = 9.81f;

    private void Start()
    {
        gameCamera = Camera.main;
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        isGrounded = controller.isGrounded;

        // Limit fall velocity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = fallSpeed;
        }

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Transform input into camara space
        var forward = gameCamera.transform.forward;
        forward.y = 0f;
        forward.Normalize();
        var right = Vector3.Cross(Vector3.up, forward);

        Vector3 movement = forward * input.z + right * input.x;
        movement.y = 0f;

        controller.Move(movement * Time.deltaTime * playerSpeed);

        // animator.SetFloat("MovementX", input.x);
        // animator.SetFloat("MovementZ", input.z);

        // If player is moving forward is camera forward
        if (input != Vector3.zero)
        {
            transform.forward = forward;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Jump speed = sqrt(2Hg)
            playerVelocity.y += Mathf.Sqrt(2 * jumpHeight * GRAVITY_VALUE);
            // animator.SetTrigger("Jump");
        }

        // Apply gravity
        playerVelocity.y -= GRAVITY_VALUE * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
