using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Configuration fields:
    [SerializeField] private float movementVelocity = 5f;

    // Cached reference
    private Rigidbody2D playerRigidbody2D;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Used for "launch" player on StartButtom down
    public void LaunchPlayerMovement()
    {
        playerRigidbody2D.velocity = Vector2.right * movementVelocity;
    }

}
