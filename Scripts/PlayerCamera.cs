using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float smoothTime = 0;
    private Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private Quaternion fixedRotation;

    private void Start()
    {
        offset = transform.position - playerPos.position;
        fixedRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        Vector3 _targetPosition = playerPos.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, smoothTime);

        transform.rotation = fixedRotation;
    }
}