using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_script : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public float gravityDirection = 1;
    public float switchTime = 3;
    public float timeRemaining;
    public float jumpForce = 10f;
    public bool IsGrounded = false;
    public bool DoubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = switchTime;
    }

    // Update is called once per frame
    void Update()
    {   
        player_controls();
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            IsGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            IsGrounded = false;
            Debug.Log("Not Grounded!");
        }
    }*/

    void OnCollisionEnter2D(Collision2D col)
    {
        print(col.otherRigidbody.transform.tag);
        IsGrounded = true;
        DoubleJump = true;
    }

    void player_controls()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            playerRigidBody.gravityScale *= -1;
            gravityDirection *= -1;
            timeRemaining = switchTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y / 2);
            playerRigidBody.AddForce(Vector2.up * jumpForce * gravityDirection);
            IsGrounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && DoubleJump)
        {
            playerRigidBody.AddForce(Vector2.up * (jumpForce / 1.5f) * gravityDirection);
            DoubleJump = false;
        }
    }
}
