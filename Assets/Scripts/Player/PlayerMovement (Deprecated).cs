using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Configuration fields:
    [SerializeField] private float movementVelocity = 10f;
    [SerializeField] private float jumpVelocity = 5f;

    // Platform's LayerMask;
    [SerializeField] private LayerMask platformLayerMask;


    // State flags:
    private bool canDoubleJump;
    private bool isTouchingPlatfrom;

    // Cached references:
    private Rigidbody2D playerRigidbody2D;
    private Collider2D playerCollider2D;
    [SerializeField] GameSession gameSession;


    // Inner fields 
    private ContactFilter2D contactFilter2D;
    private List<RaycastHit2D> raycastHit2DResults;

    void Awake()
    {
        // Get Rigidbody2D component of Player GameObject.
        playerRigidbody2D = GetComponent<Rigidbody2D>();

        // Get Collider2D component of Player GameObject.
        playerCollider2D = GetComponent<Collider2D>();

        // Initialize state flags
        canDoubleJump = false;
        isTouchingPlatfrom = false;

        // Create contactFilter2D and set platforms's LayerMask
        contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(platformLayerMask);

        // Initialize List for results of casting playerCollider2D
        raycastHit2DResults = new List<RaycastHit2D>();
    }

    void Start()
    {
        // Set velocity when the player enabled.
        //playerRigidbody2D.velocity = Vector2.right * movementVelocity;
    }

    void Update()
    {
        // On mouse left button pressed down
        //if (gameSession.gameStarted && Input.GetMouseButtonDown(0)) {
        if (Input.GetMouseButtonDown(0))
        {

            // If player is grounded call jump method
            if (IsGrounded())
            {
                Jump();
            }
            // If player is not grounded check if player can do double jump
            else if (canDoubleJump)
            {
                // Jump and set ability to double jump to false
                Jump();
                canDoubleJump = false;
            };

            if (transform.position.y > 12f)
            {
                //transform.position = new Vector3(transform.position.x, 0f);
            }
        };
    }

    private void Jump()
    {
        // Vector2D is a struct, so it's okay to create new Vector2D.
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jumpVelocity);
    }

    private bool IsGrounded()
    {
        // Cast playerCollider2D down on 0.1f using contactFilter2D.
        // Results of casting are writing to raycastHit2DResults.
        playerCollider2D.Cast(Vector2.down, contactFilter2D, raycastHit2DResults, 0.1f);

        // If number of elements contained in the raycastHit2DResults higher 1,
        // then we consider that player is touching platform.
        if (raycastHit2DResults.Count > 0)
        {
            isTouchingPlatfrom = true;
        } else
        {
            isTouchingPlatfrom = false;
        }

        // If player is touching colliders on the "Platform" layer so it can do double jump.
        // If player not touching any platforms, so it can't do double jump.
        if (isTouchingPlatfrom)
        {
            canDoubleJump = true;
        };

        // Return result of checking
        return isTouchingPlatfrom;
    }

    public void StartMovement()
    {
        // Set velocity when the player enabled.
        playerRigidbody2D.velocity = Vector2.right * movementVelocity;
    }
};
