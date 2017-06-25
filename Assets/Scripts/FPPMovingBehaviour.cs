using UnityEngine;

public class FPPMovingBehaviour : MonoBehaviour
{
    public float velocityMultiplier = 300.0f;
	public float rotationMultiplier = 500.0f;
    public float cameraRotationSpeed = 500.0f;
	public bool invert;
	[Range(-90.0f, 0.0f)]
	public float minVerticalAngle = -90.0f;
	[Range(0.0f, 90.0f)]
	public float maxVerticalAngle = 90.0f;

    private Camera fpsCamera;
    private CharacterController controller;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
        fpsCamera = Camera.main;
	}
	
	void Update ()
    {
        RotateCharacter();
        MoveCharacter();
        RotateCamera();
    }

    private void MoveCharacter()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var velocity = GetVerticalVelocity(verticalInput) 
            + GetHorizontalVelocity(horizontalInput);

        controller.SimpleMove(velocity);
    }

    private Vector3 GetHorizontalVelocity(float horizontalInput)
    {
        return transform.right * horizontalInput * velocityMultiplier * Time.deltaTime;
    }

    private Vector3 GetVerticalVelocity(float verticalInput)
    {
        return transform.forward * verticalInput * velocityMultiplier * Time.deltaTime;
    }

    private void RotateCharacter()
    {
        var horizontalRotation = Input.GetAxis("Mouse X");

        var characterRotation = horizontalRotation * rotationMultiplier * Time.deltaTime;

        transform.Rotate(transform.up, characterRotation);
    }

	private void RotateCamera()
	{
		var modifier = invert ? -1 : 1;
		var verticalRotation = Input.GetAxis("Mouse Y");


		var rotation = new Vector3(verticalRotation, 0.0f, 0.0f)
			* cameraRotationSpeed * modifier * Time.deltaTime;

        fpsCamera.transform.Rotate(rotation);
		LimitRotation();
	}

	private void LimitRotation()
	{
		var currentAngles = fpsCamera.transform.rotation.eulerAngles;

		if (currentAngles.x > 180f)
		{
			currentAngles.x -= 360f;
		}

		currentAngles.x = Mathf.Clamp(currentAngles.x, minVerticalAngle, maxVerticalAngle);
		currentAngles.z = 0.0f;

		fpsCamera.transform.rotation = Quaternion.Euler(currentAngles);
	}
}
