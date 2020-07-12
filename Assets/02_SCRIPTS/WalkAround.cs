using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAround : MonoBehaviour
{
    public float speed = 5;
    public float sensitivity = 5;
    public float smoothing = 2;
    public Transform cam;

    float velocityY = 0;
    Vector2 mouseLook;
    Vector2 smoothV;


    void Start()
    {
    }

    void FixedUpdate()
    {
        // Translation
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;
        Vector3 velocity = (transform.right * input.x + transform.forward * input.z) * speed;
        transform.position += velocity * Time.deltaTime;

        // Rotation
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        cam.transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(-mouseLook.y, -90f, 90f), Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);
    }
}
