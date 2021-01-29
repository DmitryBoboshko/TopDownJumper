using UnityEngine;

public class PlatformGroupController : MonoBehaviour
{
    // This class controls a PlatformGroup when it is below the "death zone".
    // "Death zone": value on Y-axis less than the mainCamera position by 7 units.
    // Camera Y position are set via animation by value 3.55.

    // Cached reference
    private Transform platformSupport;
    public GameObject enemiesPool;


    private void Start()
    {
        // Get PlatformSupprot gameObject.transform in PlatformGroup
        platformSupport = transform.Find("PlatformSupport");

        enemiesPool = GameObject.Find("EnemiesPool");

    }

    private void FixedUpdate()
    {
        // Value 3.55 aren't used because of camera shouldn't see a disappearance of PlatformGroup
        if (platformSupport.position.y < 3.5f - 7)
        {

            // Set new position to PlatformGroup
            transform.position = new Vector3(0, 12.5f);

            // Reset PlatformSupport position relative to PlatformGroup
            platformSupport.localPosition = new Vector3(0, 0.03f);

            // Reset Platform position relative to PlatformGroup
            transform.Find("Platform").transform.localPosition = new Vector3(0, -0.1f);

            // Reset PlatformTrigger position relative to PlatformGroup
            transform.Find("PlatformTrigger").transform.localPosition = new Vector3(0, -2.85f);

            // Attach an enemy here
            // AttachEnemyToPlatform(enemy, platformGroup.Find("Platform"));
            GameObject enemy = enemiesPool.transform.GetComponent<EnemiesPool>().getEnemyFromPool();
            if (enemy != null)
            {
                enemy.transform.position = new Vector3(Random.Range(-2.5f, 2.5f) ,platformSupport.transform.position.y);
                enemy.transform.SetParent(this.transform);
                enemy.transform.GetComponent<Enemy>().AttachEnemyToPlatform(transform.Find("Platform").gameObject);
            };

        }
    }
}
