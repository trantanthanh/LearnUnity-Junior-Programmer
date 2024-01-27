using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float forcePowerup = 200;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (hasPowerup && other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collided with " + other.gameObject.name + "with hasPowerUp = " + hasPowerup); 
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemyRb.transform.position - transform.position).normalized;
            enemyRb.AddForce(awayFromPlayer * forcePowerup, ForceMode.Impulse);
        }
    }
}
