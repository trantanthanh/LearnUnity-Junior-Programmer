using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float turnSpeed = 10f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // transform.Translate(0, 0, speed * Time.deltaTime);
        // move the vehicle forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);

        // turn the vehicle
        // transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
