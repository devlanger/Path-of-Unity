using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float minZoom = 0.5f;
    [SerializeField]
    private float maxZoom = 2;

    private float zoom = 1;

    private void LateUpdate()
    {
        zoom = Mathf.Clamp(zoom + Input.GetAxis("Mouse ScrollWheel"), minZoom, maxZoom);
        transform.position = target.transform.position + (offset * zoom);
    }
}
