using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    #region Configuration fields
    // Offset between PlatformGroups
    private readonly float platformOffsetY = 2.5f;
    // Num of PlatformGroups to instantiate 
    // (Serialized for adjusting parameters in PlatformTrigger, PlatformController)
    [SerializeField] [Range(1, 7)] private int numOfPlatforms = 7;
    #endregion

    // Reference to the Platform Prefab
    [SerializeField] private GameObject platformGroup = null;

    // Pool of platforms
    private List<GameObject> poolPlatforms;

    private void Awake()
    {
        // Generate pool of PlatformGroups
        InitialGenerating();
    }

    private void InitialGenerating()
    {
        // Initialize new List - pool of PlatformGroup instances
        poolPlatforms = new List<GameObject>();

        // PlatformGroup_1: index 10
        // PlatformGroup_2: index 11
        // PlatformGroup_3: index 12
        // PlatformGroup_4: index 13
        // PlatformGroup_5: index 14
        // PlatformGroup_6: index 15
        // PlatformGroup_7: index 16
        int currentLayerIndex = 10;

        for (float currentY = 0; currentY <= platformOffsetY * (numOfPlatforms - 1); currentY += platformOffsetY) {
            // Instantiate new PlatformGroup
            GameObject newPlatformGroup = Instantiate(platformGroup, new Vector3(0, currentY), Quaternion.identity, transform);

            // Set Layer for PlatformGroup
            newPlatformGroup.layer = currentLayerIndex;

            // Set Layer for PlatformGroup's childs
            foreach (Transform child in newPlatformGroup.transform) {
                child.gameObject.layer = currentLayerIndex;
            }

            // Add PlatformGroup to pool
            poolPlatforms.Add(newPlatformGroup);

            // Increment currentLayerIndex
            currentLayerIndex++;
        };
    }
}
