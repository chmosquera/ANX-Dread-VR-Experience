using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Moving : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float dollySpeed = 5.0f;
    private Camera camera;

    [SerializeField] private float speedH = 5.0f;
    [SerializeField] private float speedV = 5.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * dollySpeed);
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * dollySpeed);

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    private void Initialize()
    {
        camera = GetComponent<Camera>();
        Debug.Assert(camera != null);
    }

}
