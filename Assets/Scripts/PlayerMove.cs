using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    bool isJumping;
    float smoothVelocity;
    bool isEnabled;
    public float walkingForce;
    public float jumpForce;
    public float jumpSpeedBump;
    public Transform cameraTransform;
    
    public void EnablePlayer(bool enabled)
    {
      isEnabled = enabled;
    }
    public void SetJumping(bool jump)
    {
       isJumping = jump;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isJumping = false;
    }


    void FixedUpdate()
    {
        if (!isEnabled)
            return;
        Move();
        if (Input.GetKey(KeyCode.Space) && !isJumping)
            Jump();

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);
    }
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float smoothAngle = 0.05f;

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if (direction.magnitude > 0)
        {
            float rotateAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotateAngle, ref smoothVelocity, smoothAngle);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            Vector3 moveDirection = (Quaternion.Euler(0.0f, rotateAngle, 0.0f) * Vector3.forward).normalized;

            if(!isJumping)
                  rb.AddForce(moveDirection * walkingForce, ForceMode.VelocityChange);
            
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJumping = false;
    }
}