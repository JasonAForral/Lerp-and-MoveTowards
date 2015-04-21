using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform cameraTilt;
    public Transform cameraZoom;
    public Transform focus;

    public float rotateSpeed = 1f;
    public float mouseSlideSpeed = 1f;
    public float keyboardSlideSpeed = 1f;
    public float zoomSpeed = 50f;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    void LateUpdate ()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.Translate(-1.0f * mouseSlideSpeed * new Vector3(Input.GetAxis("Mouse X"), 0.0f, Input.GetAxis("Mouse Y")));
        }

        if (Input.GetButton("Fire3"))
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotateSpeed);
            cameraTilt.Rotate(Vector3.left * Input.GetAxisRaw("Mouse Y") * rotateSpeed);
            cameraTilt.localEulerAngles = Vector3.right * Mathf.Clamp(cameraTilt.localEulerAngles.x, 10f, 80f);

        }

        transform.Translate(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical") * keyboardSlideSpeed);

        cameraZoom.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        cameraZoom.localPosition = Vector3.forward * Mathf.Round(Mathf.Clamp(cameraZoom.localPosition.z, -110f, -10f));

    }
}
