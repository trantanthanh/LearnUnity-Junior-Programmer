using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 5;
    public ParticleSystem explosionParticle;
    private float forceMin = 12;
    private float forceMax = 15;
    private float torqueMin = 5;
    private float torqueMax = 10;
    private float leftSpawnX = -4f;
    private float rightSpawnX = 4f;
    private float bottomSpawnY = -3f;
    private Rigidbody targetRb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        RandomPositionSpawn();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            if (gameObject.CompareTag("Good"))
            {
                //trigger Game Over
                gameManager.GameOver();
            }
        }
    }

    void OnMouseDown()
    {
        if (!gameManager.isGameActive) return;
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        Destroy(gameObject);
    }
}
