using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRgbody;
    public float forceUpPower = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerRgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRgbody.AddForce(Vector3.up * forceUpPower, ForceMode.Impulse);
        }
    }
}
