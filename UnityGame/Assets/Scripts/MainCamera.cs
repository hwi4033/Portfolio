using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 mainCameraPosition;
    private Vector3 newPosition;

    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float cameraSpeed = 10.0f;
    [SerializeField] float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraPosition = new Vector3(0, 4.5f, -5);
    }

    void FixedUpdate()
    {
        CameraMovement();
    }

    public void CameraMovement()
    {
        newPosition = new Vector3
        (
            target.transform.position.x + mainCameraPosition.x,
            mainCameraPosition.y,
            target.transform.position.z + mainCameraPosition.z
        );

        transform.position = Vector3.Lerp(transform.position, newPosition, cameraSpeed * Time.deltaTime);        
    }

    private void Update()
    {
        // MouseRotate();
    }

    public void MouseRotate()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
        mouseY -= Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, 15, 15);

        transform.localEulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    private void LateUpdate()
    {
        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(/* πÊ«‚ */), rotateSpeed * Time.deltaTime);
    }
}