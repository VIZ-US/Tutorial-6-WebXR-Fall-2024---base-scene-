using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using WebXR;

public class Navigation : MonoBehaviour
{
    public WebXRController leftController;  // Reference to WebXR controller
    private CharacterController character;
    public Camera camera;

    private float fallingSpeed = -9.81f;
    private float verticalVelocity = 0f; // Vertical velocity for falling

    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        Vector2 inputAxis = leftController.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.fixedDeltaTime * speed);

        character.Move(new Vector3(0, fallingSpeed, 0) * Time.fixedDeltaTime);

    }
}
