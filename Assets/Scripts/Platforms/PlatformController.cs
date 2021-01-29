using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Configuration fields:
    [SerializeField] private float jumpVelocity = 10f;

    // Cached references:
    private Rigidbody2D platfromRigidbody2D;
    private Collider2D platformCollider2D;
    private GameSession gameSession;

    // State flags:
    private bool canDoubleJump;
    private bool isTouchingPlatfromSupport;
    private bool gameStarted;

    void Awake()
    {
        // Get Rigidbody2D and Collider2D components of Platform
        platfromRigidbody2D = GetComponent<Rigidbody2D>();
        platformCollider2D = GetComponent<Collider2D>();

        // Set flags
        isTouchingPlatfromSupport = false;
        canDoubleJump = false;
        gameStarted = false;

        gameSession = GameObject.Find("GameSession").transform.GetComponent<GameSession>();
    }

    private void OnEnable()
    {
        gameSession.GameStarted += setGameStartedFlag;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && gameStarted)
        {
            if (isTouchingPlatfromSupport)
            {
                Jump();

                // When Platform "jump" first time it can double jump
                canDoubleJump = true;
            } else if (canDoubleJump)
            {
                Jump();

                // When Platform "jump" second time it can't double jump
                canDoubleJump = false;
            }
        };
    }

    private void Jump()
    {
        platfromRigidbody2D.velocity = new Vector2(0, -jumpVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* If Platform collided with the PlatformSupport, then consider, 
        that they are touching each other, and Platform can "jump" */
        isTouchingPlatfromSupport = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /* If Platform exit from collision with the PlatformSupport, then consider, 
        that they are no more touching each other, and Platform can't "jump" */
        isTouchingPlatfromSupport = false;
    }

    private void setGameStartedFlag()
    {
        gameStarted = true;
    }

}
