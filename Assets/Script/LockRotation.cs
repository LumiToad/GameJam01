using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    Quaternion rotation;
    Vector3 position;

    private void Awake()
    {
        rotation = transform.rotation;
        position = transform.position;
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = position;
    }
}
