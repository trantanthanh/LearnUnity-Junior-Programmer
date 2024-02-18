using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    private float torqueMin = 5f;
    private float torqueMax = 10f;
    private float topSpawnY = 19f;
    private float leftSpawnX = -14f;
    private float rightSpawnX = 14f;

    private Rigidbody foodRb;
    void Start()
    {
        RandomPositionSpawn();
        foodRb = GetComponent<Rigidbody>();
        foodRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPositionSpawn()
    {
        transform.position = new Vector3(Random.Range(leftSpawnX, rightSpawnX), topSpawnY);
    }

    Vector3 RandomTorque()
    {
        return Random.insideUnitSphere.normalized * Random.Range(torqueMin, torqueMax);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check if on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
