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
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = switchTime;
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce * gravityDirection);
        }
    }
}
