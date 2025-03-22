using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target is null");
            return;
        }

        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }
}
