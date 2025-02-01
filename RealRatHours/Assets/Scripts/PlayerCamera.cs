using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX = 15f;
    public float sensY = 15f;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public Transform player;
    public float distance = 3f;

    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private float defaultHeight;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        defaultHeight = 2f * GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void LateUpdate()
    {

          Vector3 target = player.position + (transform.position - player.position).normalized * distance;
      transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
      transform.LookAt(player); 
    }
}
