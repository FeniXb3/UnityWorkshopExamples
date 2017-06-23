using UnityEngine;

public class PushingBehaviour : MonoBehaviour
{
    public Vector3 forceVector = new Vector3(0f, 0f, 10f);

    Rigidbody rigidBody;

    void Start()
    {
		rigidBody = GetComponent<Rigidbody>();
	}

    void Update()
	{
        rigidBody.AddForce(forceVector, ForceMode.Impulse);
    }
}
