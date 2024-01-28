using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Transform lookAtTarget; 
    public Vector3 offset; 

    void LateUpdate()
    {
        if (target == null || lookAtTarget == null)
        {
            return;
        }

        
        Vector3 desiredPosition = target.position + offset;

        transform.position = desiredPosition;

        transform.LookAt(lookAtTarget);
    }
}