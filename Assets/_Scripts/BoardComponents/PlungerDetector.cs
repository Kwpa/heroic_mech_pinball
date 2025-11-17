using UnityEngine;

public class PlungerDetector : MonoBehaviour
{
    [SerializeField] private Plunger plunger;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            plunger.AddRbToList(rb);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            plunger.RemoveRbFromList(rb);
        }
    }
}
