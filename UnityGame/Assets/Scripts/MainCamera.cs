using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : CameraCenter
{
    [SerializeField] float distance = 5.0f;
    [SerializeField] float height = 5.0f;
    [SerializeField] float cameraSpeed = 10.0f;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float mouseSpeed = 5.0f;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            MouseRotate();
        }
    }

    public void MouseRotate()
    {
        mouseX = Input.GetAxisRaw("Mouse X"); // * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y"); // * mouseSpeed * Time.deltaTime;

        // mouseY = Mathf.Clamp(mouseY, 15, 15);

        transform.RotateAround(target.transform.position, transform.up, mouseX * mouseSpeed * Time.deltaTime);
        transform.RotateAround(target.transform.position, transform.right, -mouseY * mouseSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        // https://yoonstone-games.tistory.com/114
    }

    private void LateUpdate()
    {
        // CameraMovement();
    }

    public void CameraMovement()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position - (target.transform.forward * distance) + Vector3.up * height, cameraSpeed * Time.deltaTime);

        transform.LookAt(target.transform.position + Vector3.up * height);

        // transform.forward = Vector3.Lerp(transform.forward, target.transform.forward - (target.transform.forward * distance), cameraSpeed * Time.deltaTime);
    }
}