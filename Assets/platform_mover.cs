using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_mover : MonoBehaviour
{
    public float platform_speed = -0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= Vector3.left * platform_speed;
        if (transform.position.x < -50) Destroy(transform.gameObject);
    }
}
