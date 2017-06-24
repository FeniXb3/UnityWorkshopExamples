using UnityEngine;

public class RotateWithMouseBehaviour : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public bool invert;
    [Range(-90.0f, 0.0f)]
    public float minVerticalAngle = -90.0f;
	[Range(0.0f, 90.0f)]
    public float maxVerticalAngle = 90.0f;


	void Update ()
    {
        var modifier = invert ? -1 : 1;
        var horizontalRotation = Input.GetAxis("Mouse X");
        var verticalRotation = Input.GetAxis("Mouse Y");


        var rotation = new Vector3(verticalRotation, horizontalRotation, 0.0f)
            * rotationSpeed * modifier * Time.deltaTime;

        transform.Rotate(rotation);
        LimitRotation();
    }

    private void LimitRotation()
    {
        var currentAngles = transform.rotation.eulerAngles;

        if (currentAngles.x > 180f)
        {
            currentAngles.x -= 360f;
        }

        currentAngles.x = Mathf.Clamp(currentAngles.x, minVerticalAngle, maxVerticalAngle);
        currentAngles.z = 0.0f;

        transform.rotation = Quaternion.Euler(currentAngles);
    }
}
