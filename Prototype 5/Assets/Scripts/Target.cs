using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float forceMin = 12;
    private float forceMax = 16;
    private float torqueMin = 5;
    private float torqueMax = 10;
    private float leftSpawnX = -4f;
    private float rightSpawnX = 4f;
    private float bottomSpawnY = -3f;
    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        RandomPositionSpawn();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBound();
    }

    void RandomPositionSpawn()
    {
        transform.position = new Vector3(Random.Range(leftSpawnX, rightSpawnX), bottomSpawnY);
    }

    Vector3 RandomForce()
    {
        Vector3 targetPoint = new Vector3(Random.Range(-2f, 2f), 5f, 0);
        Vector3 direction = (targetPoint - transform.position).normalized;
        return direction * Random.Range(forceMin, forceMax);
    }

    Vector3 RandomTorque()
    {
        return Random.insideUnitSphere.normalized * Random.Range(torqueMin, torqueMax);
    }

    void CheckOutOfBound()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
