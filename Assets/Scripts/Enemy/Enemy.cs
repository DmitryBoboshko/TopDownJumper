using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject attachedPlatform;

    private void OnEnable()
    {
        // Attach the enemy to platform onEnable

    }

    void Update()
    {
        // Change position accordingly to platform the enemy attached to
        // Don't change X coord
        transform.position = new Vector3(transform.position.x, attachedPlatform.transform.position.y);
    }

    public void AttachEnemyToPlatform(GameObject platform)
    {
        attachedPlatform = platform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy hits Player!");
    }
}
