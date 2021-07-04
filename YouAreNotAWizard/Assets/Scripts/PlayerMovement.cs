using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public Vector3 moveDir;
    public CharacterController controller;
    public float movementSpeed;
    public float turnSpeed;
    public float turnSmoothTime;
    public Transform cam;
    public float playerGravity;
    public PlayerScript playerScript;

    void Update()
    {
        if (playerScript.isDead == false)
            MoveThePlayer();
        ApplyGravity();
    }

    void ApplyGravity()
    {
        // Vector3 gravityVector = Quaternion.Euler(0f, playerGravity, 0f) * Vector3.down;
        // controller.Move(gravityVector * Time.deltaTime);
        controller.Move(Vector3.down * playerGravity);
    }
    void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * (movementSpeed * Time.deltaTime));
        }
    }
}
