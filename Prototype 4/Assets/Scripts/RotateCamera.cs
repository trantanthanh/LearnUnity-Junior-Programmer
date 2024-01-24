using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float mouseXInput = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {
            if (mouseXInput != 0)
            {
                transform.Rotate(Vector3.up, mouseXInput * rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
        }
    }
}
