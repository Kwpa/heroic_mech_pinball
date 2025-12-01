using UnityEngine;
using UnityEngine.Events;

public class EnterRamp : MonoBehaviour
{
    public UnityEvent enteredRail;
    private bool active;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && active)
        {
            enteredRail.Invoke();
            Debug.Log("Rail Entered");
        }
    }

    public void ActivateRail()
    {
        active = true;
    }

    public void DisableRail()
    {
        active = false;
    }
}
