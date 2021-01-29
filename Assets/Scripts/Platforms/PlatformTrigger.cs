using System;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    // Cached references
    private GameObject platformGroup;
    private GameObject platformSupport;

    // How far to move PlatformSupport and PlatformTrigger
    private const float moveDistance = 2.5f;

    // Action for IncrementScore
    public static event Action DoIncrementScore;


    void Start()
    {
        // Get PlatformGroup gameObject
        platformGroup = transform.parent.gameObject;

        // Get PlatformSupport gameObject via PlatformGroup
        platformSupport = platformGroup.transform.Find("PlatformSupport").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get current Y position of PlatformSupport and PlatformTrigger
        float currentPlatformSupportPosY = platformSupport.transform.position.y;
        float currentPlatformTriggerPosY = transform.position.y;

        // Set a new position to PlatformSupport and PlatformTrigger below the current value on moveDistance value
        platformSupport.transform.position = new Vector3(0, currentPlatformSupportPosY - moveDistance);
        transform.position = new Vector3(0, currentPlatformTriggerPosY - moveDistance);

        if (Mathf.Floor(platformSupport.transform.position.y) == 0)
        {
            //Debug.Log("Score++");
            DoIncrementScore();

        };

        GameObject enemy = platformGroup.transform.Find("Enemy(Clone)").gameObject;
        if (enemy != null)
        {
            platformGroup.transform.GetComponent<PlatformGroupController>().enemiesPool.GetComponent<EnemiesPool>().returnEnemyToPool(enemy);
        }
    }
}
