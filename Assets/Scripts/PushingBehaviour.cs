using UnityEngine;

public class PushingBehaviour : MonoBehaviour
{
    public Vector3 forceVector = new Vector3(0f, 0f, 10f);

	void Start()
    {
		var rigidBody = GetComponent<Rigidbody>();

		rigidBody.AddForce(forceVector, ForceMode.Impulse);		
	}
}
