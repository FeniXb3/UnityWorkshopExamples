using UnityEngine;

public class MovingBehaviour : MonoBehaviour
{
    CharacterController controller;

	void Start ()
    {
        controller = GetComponent<CharacterController>();	
	}
	
	void Update ()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var velocity = transform.forward * verticalInput;

        transform.Rotate(transform.up, horizontalInput);
        controller.SimpleMove(velocity);
	}
}
