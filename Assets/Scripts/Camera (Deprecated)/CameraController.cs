using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject currentTarget;
    [SerializeField] [Range(0, 1)] private float smoothSpeed = 0.1f;
    [SerializeField] private const float cameraOffsetZ = -10f;
    [SerializeField] private float cameraIngameOffsetY = 3.5f;

    // State fields
    private float currentOffsetY;
    float desiredCameraPosY;

    private const float initOffsetY = 0;

    private Animator cameraAnim;

    void Awake()
    {
        cameraAnim = transform.GetComponent<Animator>();
        //SetCameraIngameOffsetY();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump")) {
            cameraAnim.Play("Base Layer.CameraJumpAnimation");
        }

        //// Get current camera Y coordinate
        //float cameraPosY = transform.position.y;

        //// Calculate desired camera's Y coordinate: target Y coord + current camera Offset
        //desiredCameraPosY = currentTarget.transform.position.y + currentOffsetY;

        //// Smooth value
        //float smoothedCameraPosY = Mathf.Lerp(cameraPosY, desiredCameraPosY, smoothSpeed);

        //// Prepare new camera position
        //Vector3 newCameraPos = new Vector3(0, smoothedCameraPosY, cameraOffsetZ);
        //// Set new camera position
        //transform.position = newCameraPos;
    }

    //public void SetCameraIngameOffsetY()
    //{
    //    //currentOffsetY = cameraIngameOffsetY;

    //    cameraAnim.Play("Base Layer.CameraMoveToPlayState");
    //}
}
