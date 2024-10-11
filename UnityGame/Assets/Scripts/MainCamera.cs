using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : CameraCenter
{
    [SerializeField] Vector3 targetHead;
    [SerializeField] LayerMask cameraCollision;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float mouseSpeed = 5.0f;

    private void Update()
    {
        targetHead = target.transform.position + Vector3.up * 3.0f;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            CameraCollision();

            MouseRotate();
        }
    }

    public void MouseRotate()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        // mouseY = Mathf.Clamp(mouseY, 15, 15);

        transform.RotateAround(targetHead, transform.up, mouseX * mouseSpeed * Time.deltaTime);
        transform.RotateAround(targetHead, transform.right, -mouseY * mouseSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    public void CameraCollision()
    {
        Vector3 distance = transform.position - targetHead;
        RaycastHit hit;

        Debug.DrawRay(targetHead, distance, Color.red);

        if (Physics.Raycast(targetHead, distance, out hit, float.MaxValue, cameraCollision))
        {
            Debug.DrawRay(targetHead, distance, Color.red);

            transform.position = hit.point - distance.normalized;
        }
    }
}