using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFalled : MonoBehaviour
{
    private float bottomBoundY = -26f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomBoundY)
        {
            Destroy(gameObject);
        }
    }
}
