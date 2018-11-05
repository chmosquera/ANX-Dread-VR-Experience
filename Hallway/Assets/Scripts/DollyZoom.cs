﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DollyZoom : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float dollySpeed = 5.0f;
    private Camera camera;
    private float initialFrustumHeight;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * dollySpeed);

        float currentDistance = Vector3.Distance(transform.position, target.position);
        camera.fieldOfView = ComputeFieldOfView(initialFrustumHeight, currentDistance);
    }

    private void Initialize()
    {
        camera = GetComponent<Camera>();
        Debug.Assert(camera != null);

        float distanceFromTarget = Vector3.Distance(transform.position, target.position);
        initialFrustumHeight = ComputeFrustumHeight(distanceFromTarget);
    }

    private float ComputeFrustumHeight(float distance)
    {
        return (2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }

    private float ComputeFieldOfView(float height, float distance)
    {
        return (2.0f * Mathf.Atan(height * 0.5f / distance) * Mathf.Rad2Deg);
    }
}
