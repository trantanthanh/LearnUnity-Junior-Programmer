using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -7);

    void LateUpdate()
    {
        // offset the camera behind the player by adding to the player's position
        transform.position = player.transform.position + offset;
    }
}
