using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] float speed = 10f;
    [SerializeField] float turnSpeed = 10f;
    [SerializeField] float forcePower = 10f;
    [SerializeField] float wheelRadius = 0.2f;//radius of wheel(meter)
    [SerializeField] List<WheelCollider> allWheelColliders;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI textSpeedometer;
    [SerializeField] TextMeshProUGUI textRPM;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float forwardInput;
    private float currentSpeed;
    private float currentRPM;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (IsOnGround())
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
    }

    void UpdateSpeedometer()
    {
        //Rigidbody.velocity.magnitude is meter/second -> Kilometer/Hour by multiple 3.6
        currentSpeed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        textSpeedometer.text = "Speed : " + currentSpeed + " km/h";

        //caculate RPM
        //circumference = 2 * PI * radius
        //speed KM/H = circumference * RPM * 60 (minutes) / 1000 (m)
        // RPM = (speed KM/H) * 1000/(2*PI*wheelRadius * 6)
        currentRPM = Mathf.RoundToInt(currentSpeed * 1000 / (12 * Mathf.PI * wheelRadius));
        textRPM.text = "RPM : " + currentRPM;
    }

    bool IsOnGround()
    {
        foreach (WheelCollider wheel in allWheelColliders)
        {
            if (!wheel.isGrounded)
            {
                return false;
            }
        }
        return true;
    }
}
