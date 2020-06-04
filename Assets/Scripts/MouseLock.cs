using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
	public float Sensitivity = 100f;

	public Transform playerBody;

	private float xRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 40, 150);

        transform.localRotation = Quaternion.Euler(xRotation, -83.554f, 3.598f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
