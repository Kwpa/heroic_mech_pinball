using UnityEngine;
using UnityEngine.Events;

public class ExitRamp : MonoBehaviour
{
    public UnityEvent exitedRail;
    private bool railEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!railEntered) return;

        if (other.gameObject.CompareTag("Ball"))
        {
            exitedRail.Invoke();
            railEntered = false;
            Debug.Log("Rail Exited");
        }
    }

    public void OnRailEntered()
    {
        railEntered = true;
    }
}
