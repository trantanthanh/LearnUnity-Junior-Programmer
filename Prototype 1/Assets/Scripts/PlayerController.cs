using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] float speed = 10f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] float forcePower = 10f;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI textSpeedometer;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // transform.Translate(0, 0, speed * Time.deltaTime);
        // move the vehicle forward
        //transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * forcePower * forwardInput);

        // turn the vehicle
        // transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        UpdateSpeedometer();
    }

    void UpdateSpeedometer()
    { 
        currentSpeed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        textSpeedometer.text = "Speed : " + currentSpeed + " km/h";
    }
}
