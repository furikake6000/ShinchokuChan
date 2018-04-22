using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    const float JUMP_POW = 5.0f;
    const float SPEED = 1.0f;

    private Animator animator;
    private Rigidbody rb;
    private bool is_jumping;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        SetIsJumping(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump") && !is_jumping)
        {
            rb.AddForce(0, JUMP_POW, 0, ForceMode.Impulse);
            SetIsJumping(true);
        }
        
        float speedX = rb.velocity.x;
        if (Mathf.Abs(speedX) < SPEED)
        {
            rb.AddForce(Vector3.left * -Input.GetAxis("Horizontal") * SPEED * 10.0f);
        }
        if(speedX < 0)
        {
            if(transform.localRotation.y < 1.0f)
            {
                transform.Rotate(Vector3.up * 30.0f);
            }
        }
        else if (speedX > 0)
        {
            if (transform.localRotation.y > 0.1f)
            {
                transform.Rotate(Vector3.up * -30.0f);
            }
        }

        animator.SetFloat("speed", rb.velocity.magnitude);
    }

    void OnTriggerEnter(Collider collider) {
        SetIsJumping(false);
        Debug.Log("Ground Detected!");
    }

    void SetIsJumping(bool state)
    {
        animator.SetBool("is_jumping", state);
        is_jumping = state;

        Debug.Log("IS JUMPING: " + is_jumping);
    }

}
