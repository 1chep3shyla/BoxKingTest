using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform target;

    void Update()
    {
        transform.LookAt(-Camera.main.transform.position);
    }
}
