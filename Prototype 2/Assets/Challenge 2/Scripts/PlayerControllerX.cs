using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeIntervalSpawnDog = 1.5f;

    private float timeInterval = 0;
    // Update is called once per frame
    void Update()
    {
        timeInterval -= Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeInterval <= 0)
            {
                timeInterval = timeIntervalSpawnDog;
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            }
        }
    }
}
