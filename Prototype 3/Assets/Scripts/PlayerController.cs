using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    private bool isOnGround = true;

    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            dirtParticle.Stop();
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!isGameOver)
            {
                dirtParticle.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            explosionParticle.Play();
            isGameOver = true;
            playerAnimator.SetBool("Death_b", true);
            if (isOnGround)
            {
                playerAnimator.SetInteger("DeathType_int", 1);
            }
            else
            {
                playerAnimator.SetInteger("DeathType_int", 2);
            }
        }
    }

    public bool IsOnGround()
    {
        return isOnGround;
    }
}
