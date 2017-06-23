using UnityEngine;

public class PushingBehaviour : MonoBehaviour
{
	void Start()
    {
		var rigidBody = GetComponent<Rigidbody>();
		var forceVector = new Vector3(0f, 0f, 10f);

		rigidBody.AddForce(forceVector, ForceMode.Impulse);		
	}
}
