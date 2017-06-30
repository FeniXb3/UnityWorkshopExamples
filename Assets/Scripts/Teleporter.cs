using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            var rotation = Quaternion.Euler(target.rotation.eulerAngles);

           
            collider.transform.SetPositionAndRotation(target.position, rotation);
        }
    }
}
