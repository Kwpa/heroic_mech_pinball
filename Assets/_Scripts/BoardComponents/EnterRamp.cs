using UnityEngine;
using UnityEngine.Events;

public class EnterRamp : MonoBehaviour
{
    public UnityEvent enteredRail;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            enteredRail.Invoke();
            Debug.Log("Rail Entered");
        }
    }
}
