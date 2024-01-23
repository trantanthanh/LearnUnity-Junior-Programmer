using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speedMove = 10f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerControllerScript.isGameOver)
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);
        }
        else if (!playerControllerScript.IsOnGround())
        {
            transform.Translate(Vector3.left * speedMove * Time.deltaTime);
        }
    }
}
