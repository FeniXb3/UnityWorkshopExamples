using UnityEngine;

public class MovingBehaviour : MonoBehaviour
{
    public float velocityMultiplier = 1.0f;
    public float rotationMultiplier = 1.0f;

    CharacterController controller;

	void Start ()
    {
        controller = GetComponent<CharacterController>();	
	}
	
	void Update ()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var velocity = transform.forward * verticalInput * velocityMultiplier;
        var rotation = horizontalInput * rotationMultiplier;

        transform.Rotate(transform.up, rotation);
        controller.SimpleMove(velocity);
	}
}
