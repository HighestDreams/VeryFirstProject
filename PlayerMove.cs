using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController player;

    public float speed = 15f;

    public Transform groundCheck;

    public LayerMask groundMask;

    private float groundDistance = 0.4f;

    private bool isGrounded;

    private float gravity = -40f; // 9.81f

    private float jumpHeight = 4f;

    private Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            speed = speed * 2;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl)) {
            speed = speed / 2;
        }

        if(Input.GetButton("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        player.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        player.Move(velocity * Time.deltaTime);
    }
}
