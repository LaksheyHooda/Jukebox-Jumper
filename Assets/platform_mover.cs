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
    void Update()
    {
        transform.position -= Vector3.left * platform_speed;
        if (transform.position.x < -100) Destroy(transform.gameObject);
    }
}
