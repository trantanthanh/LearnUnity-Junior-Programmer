using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 14f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoving();
    }

    void UpdateMoving()
    {
        float horizalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right *  horizalInput * speed * Time.deltaTime);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
