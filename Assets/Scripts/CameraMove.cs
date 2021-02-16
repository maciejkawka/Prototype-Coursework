using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    public float rotateSpeed = 5.0f;
    public float smoothFactor = 0.5f;

    Vector3 cameraOffset;
    Vector3 tempOffset;
    
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }


    void LateUpdate()
    {
        Quaternion turnCam = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
        
        cameraOffset = turnCam * cameraOffset;
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        transform.LookAt(playerTransform);
    }
}
