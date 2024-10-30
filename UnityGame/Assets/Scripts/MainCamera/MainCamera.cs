using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MainCameraCenter
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
        // CameraRayCollision();

        MouseRotate();
    }

    public void MouseRotate()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        transform.RotateAround(targetHead, transform.up, mouseX * mouseSpeed * Time.deltaTime);
        transform.RotateAround(targetHead, transform.right, -mouseY * mouseSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    public void CameraRayCollision()
    {
        Vector3 distance = transform.position - targetHead;
        RaycastHit hit;        

        if (Physics.Raycast(targetHead, distance, out hit, int.MaxValue, cameraCollision))
        {
            transform.position = hit.point - distance.normalized;
        }       
    }
}